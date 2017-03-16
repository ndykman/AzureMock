using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace NModelsoft.Azure.Mock.Storage.Table
{
    /// <summary>
    /// Exception class.
    /// </summary>
    public class TableQueryParseException : ApplicationException
    {
        public TableQueryParseException() : base()
        {
        
        }

        public TableQueryParseException(string message) : base(message)
        {
            
        }

        public TableQueryParseException(string message, Exception inner) : base(message, inner)
        {
            
        }

    }

    public enum QueryComparsionOperation
    {
        Equal,
        NotEqual,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual
    }

    /// <summary>
    /// This represents a node in the expression parse tree for a table storage query.
    /// </summary>
    public abstract class QueryExpression
    {
        /// <summary>
        /// Build an expression that represents the query against a specific class.
        /// </summary>
        /// <param name="pe"></param>
        /// <returns></returns>
        public abstract Expression CreateExpressionBody(ParameterExpression pe);
        /// <summary>
        /// Build an expression the represents the query against a DynamicTableEntity.
        /// </summary>
        /// <param name="pe"></param>
        /// <returns></returns>
        public abstract Expression CreateExpressionBodyDynamic(ParameterExpression pe);
    }

    /// <summary>
    /// This is a not (...) expression
    /// </summary>
    public class NotQueryExpression : QueryExpression
    {
        public QueryExpression NegatedExpression { get; set; }
        public override Expression CreateExpressionBody(ParameterExpression pe)
        {
            return Expression.Negate(NegatedExpression.CreateExpressionBody(pe));
        }

        public override Expression CreateExpressionBodyDynamic(ParameterExpression pe)
        {
            return Expression.Negate(NegatedExpression.CreateExpressionBodyDynamic(pe));
        }
    }

    /// <summary>
    /// This is an (...) or (...) expression
    /// </summary>
    public class OrQueryExpression : QueryExpression
    {
        public QueryExpression LeftSideExpression { get; set; }
        public QueryExpression RightSideExpression { get; set; }
        public override Expression CreateExpressionBody(ParameterExpression pe)
        {
           return Expression.OrElse(LeftSideExpression.CreateExpressionBody(pe),
                                     RightSideExpression.CreateExpressionBody(pe));
        }

        public override Expression CreateExpressionBodyDynamic(ParameterExpression pe)
        {
            return Expression.OrElse(LeftSideExpression.CreateExpressionBodyDynamic(pe),
                                     RightSideExpression.CreateExpressionBodyDynamic(pe));
        }
    }

    /// <summary>
    /// This is an (...) and (...) expression
    /// </summary>
    public class AndQueryExpression : QueryExpression
    {
        public QueryExpression LeftSideExpression { get; set; }
        public QueryExpression RightSideExpression { get; set; }
        public override Expression CreateExpressionBody(ParameterExpression pe)
        {
           return Expression.AndAlso(LeftSideExpression.CreateExpressionBody(pe),
                                     RightSideExpression.CreateExpressionBody(pe));
        }

        public override Expression CreateExpressionBodyDynamic(ParameterExpression pe)
        {
            return Expression.AndAlso(LeftSideExpression.CreateExpressionBodyDynamic(pe),
                                     RightSideExpression.CreateExpressionBodyDynamic(pe));
        }
    }

    /// <summary>
    /// This an [key] [op] [value] expression. For example PartitionKey eq 'PK1'
    /// </summary>
    /// <typeparam name="T">The type of the value being compared.</typeparam>
    public class ComparisonExpression<T> : QueryExpression
    {
        public string Key { get; set; }
        public QueryComparsionOperation ComparisonOperation { get; set; }
        public T Value { get; set; }

        public override Expression CreateExpressionBody(ParameterExpression pe)
        {
            // Only equality operations make sense for binary and Guids.
            if (typeof (T) == typeof (Guid) || typeof (T) == typeof (byte[]))
            {
                if (ComparisonOperation != QueryComparsionOperation.Equal ||
                    ComparisonOperation != QueryComparsionOperation.NotEqual)
                    throw new TableQueryParseException();
            }

            return CreateComparsionExpression(pe);
        }

        private Expression CreateComparsionExpression(ParameterExpression pe)
        {
            // Basically, create an expression that see if the property that has the same name as the Key value
            // is the same as the Value represented as a constant. 
            try
            {
                if (ComparisonOperation == QueryComparsionOperation.Equal)
                {
                    return Expression.Equal(
                        Expression.PropertyOrField(pe, Key),
                        Expression.Constant(Value, typeof(T)));
                }
                if (ComparisonOperation == QueryComparsionOperation.NotEqual)
                {
                    return Expression.NotEqual(
                        Expression.PropertyOrField(pe, Key),
                        Expression.Constant(Value, typeof(T)));
                }
                if (ComparisonOperation == QueryComparsionOperation.LessThan)
                {
                    return Expression.LessThan(
                        Expression.PropertyOrField(pe, Key),
                        Expression.Constant(Value, typeof(T)));
                }
                if (ComparisonOperation == QueryComparsionOperation.LessThanOrEqual)
                {
                    return Expression.LessThanOrEqual(
                        Expression.PropertyOrField(pe, Key),
                        Expression.Constant(Value, typeof(T)));
                }
                if (ComparisonOperation == QueryComparsionOperation.GreaterThan)
                {
                    return Expression.GreaterThan(
                        Expression.PropertyOrField(pe, Key),
                        Expression.Constant(Value, typeof(T)));
                }
                if (ComparisonOperation == QueryComparsionOperation.GreaterThanOrEqual)
                {
                    return Expression.GreaterThanOrEqual(
                        Expression.PropertyOrField(pe, Key),
                        Expression.Constant(Value, typeof(T)));
                }
            }
            catch (Exception e)
            {
                throw new TableQueryParseException("Error occured while trying to create comparison expression",e);
            }
            
            throw new TableQueryParseException("Unexpected operation type found");
        }

        public override Expression CreateExpressionBodyDynamic(ParameterExpression pe)
        {
            // Only equality operations make sense for binary and Guids.
            if (typeof(T) == typeof(Guid) || typeof(T) == typeof(byte[]))
            {
                if (ComparisonOperation != QueryComparsionOperation.Equal ||
                    ComparisonOperation != QueryComparsionOperation.NotEqual)
                    throw new TableQueryParseException("An non equality operation was specified on a type that does only supports equality operations.");
            }

            return CreateComparsionExpressionDynamic(pe);
        }

        private Expression CreateComparsionExpressionDynamic(ParameterExpression pe)
        {
            // These are properties of the DynamcTableEntity, so just use the
            // regular comparison helper. 
            if (Key == "PartitionKey" || Key == "RowKey")
            {
                return CreateComparsionExpression(pe);
            }

            try
            {
                if (ComparisonOperation == QueryComparsionOperation.Equal)
                {
                    return Expression.Equal(GetEntityPropertyExpression(pe),
                        Expression.Constant(Value,typeof(T)));   
                }
                if (ComparisonOperation == QueryComparsionOperation.NotEqual)
                {
                    return Expression.NotEqual(GetEntityPropertyExpression(pe), 
                        Expression.Constant(Value, typeof(T)));
                }
                if (ComparisonOperation == QueryComparsionOperation.LessThan)
                {
                    return Expression.LessThan(GetEntityPropertyExpression(pe), 
                        Expression.Constant(Value, typeof(T)));
                }
                if (ComparisonOperation == QueryComparsionOperation.LessThanOrEqual)
                {
                    return Expression.LessThanOrEqual(GetEntityPropertyExpression(pe), 
                        Expression.Constant(Value, typeof(T)));
                }
                if (ComparisonOperation == QueryComparsionOperation.GreaterThan)
                {
                    return Expression.GreaterThan(GetEntityPropertyExpression(pe), 
                        Expression.Constant(Value, typeof(T)));
                }
                if (ComparisonOperation == QueryComparsionOperation.GreaterThanOrEqual)
                {
                    return Expression.GreaterThanOrEqual(GetEntityPropertyExpression(pe), 
                        Expression.Constant(Value, typeof(T)));
                }
            }
            catch (Exception e)
            {
                throw new TableQueryParseException("Error occured while trying to create comparison expression", e);
            }

            throw new TableQueryParseException("Unexpected operation type found");
        }

        private Expression GetEntityPropertyExpression(ParameterExpression pe)
        {
            // Basically, create an expression that works like the following:
            // DynamicTableEntity dte;
            // dte.Properties[Key].StringValue for a string or
            // dte.Properties[Key].BooleanValue.Value for a boolean. And so on.

            // The indexer property of Properties dictionary.
            var indexer = typeof (IDictionary<string, EntityProperty>).GetProperty("Item");

            if (typeof (T) == typeof (byte[]))
            {
                return Expression.Property(
                    Expression.MakeIndex(
                        Expression.Property(pe, "Properties"),
                        indexer, new[] {Expression.Constant(Key, typeof (string))}),
                        "BinaryValue");
            }
            if (typeof(T) == typeof(bool))
            {
               return Expression.Property(
                   Expression.Property(
                        Expression.MakeIndex(
                            Expression.Property(pe, "Properties"),
                            indexer, new[] {Expression.Constant(Key, typeof (string))}),
                        "BooleanValue"),
                    "Value");
            }
            if (typeof(T) == typeof(DateTimeOffset))
            {
                return Expression.Property(
                    Expression.Property(
                        Expression.MakeIndex(
                            Expression.Property(pe, "Properties"),
                            indexer, new[] {Expression.Constant(Key, typeof (string))}),
                        "DateTimeOffsetValue"),
                    "Value");
            }
            if (typeof(T) == typeof(double))
            {
                return Expression.Property(
                    Expression.Property(
                        Expression.MakeIndex(
                            Expression.Property(pe, "Properties"),
                            indexer, new[] {Expression.Constant(Key, typeof (string))}),
                        "DoubleValue"),
                    "Value");
            }
            if (typeof(T) == typeof(Guid))
            {
                return Expression.Property(
                    Expression.Property(
                        Expression.MakeIndex(
                            Expression.Property(pe, "Properties"),
                            indexer, new[] {Expression.Constant(Key, typeof (string))}),
                        "GuidValue"),
                    "Value");
            }
            if (typeof(T) == typeof(int))
            {
                return Expression.Property(
                    Expression.Property(
                        Expression.MakeIndex(
                            Expression.Property(pe, "Properties"),
                            indexer, new[] {Expression.Constant(Key, typeof (string))}),
                        "Int32Value"),
                    "Value");
            }
            if (typeof(T) == typeof(long))
            {
                return Expression.Property(
                   Expression.Property(
                       Expression.MakeIndex(
                           Expression.Property(pe, "Properties"),
                           indexer, new[] { Expression.Constant(Key, typeof(string))}),
                       "Int64Value"),
                   "Value");
            }
            if (typeof(T) == typeof(string))
            {
                return Expression.Property(
                    Expression.MakeIndex(
                        Expression.Property(pe, "Properties"),
                            indexer, new[] {Expression.Constant(Key, typeof (string))}),
                        "StringValue");
            }
            throw new TableQueryParseException("Error occured when creating a DynamicTableEntity property access expression");
        }
    }

    /// <summary>
    /// Take a table query filter string that is created by the Azure Table Storage API and parse it. 
    /// </summary>
    public class TableQueryParser
    {
        /// <summary>
        /// Create an expression that represents a method that takes in a value of type T and
        /// returns true if it matches the filter string query, false otherwise.
        /// </summary>
        /// <typeparam name="T">The type of entity being queried.</typeparam>
        /// <param name="filterString">The filter represented as a string.</param>
        /// <returns></returns>
        public Expression<Func<T, bool>> CreateFilterExpresssion<T>(string filterString)
        {
            var q = ParseFilter(filterString);
            var pe = Expression.Parameter(typeof(T), "o");
            return Expression.Lambda<Func<T, bool>>(q.CreateExpressionBody(pe), pe);
        }

        /// <summary>
        /// Create an expression that represents a method that takes in a DynamicTableEntity and that
        /// returns true if that entity matches the filter string query, false otherwise.
        /// </summary>
        /// <param name="filterString"></param>
        /// <returns></returns>
        public Expression<Func<DynamicTableEntity, bool>> CreateFilterExpressionDynamic(string filterString)
        {
            var q = ParseFilter(filterString);
            var pe = Expression.Parameter(typeof(DynamicTableEntity), "o");
            return Expression.Lambda<Func<DynamicTableEntity, bool>>(q.CreateExpressionBodyDynamic(pe), pe);
        }

        /// <summary>
        /// Any query string (or substring) matches one of these patterns.
        /// not [query]
        /// [query1] (and|or) [query2]
        /// [key] (eq|ne|lt|le|gt|ge) [value]
        /// </summary>
        private readonly Regex _notExpressionRegex = new Regex(@"^(not)\s+(.+)$");
        private readonly Regex _comparsionRegex = new Regex(@"^(?'lp'\()*(\w+)\s*(eq|ne|lt|le|gt|ge)\s*(.+)(?'rp-lp'\))*(?(lp)(?!))$");
        private readonly Regex _combinationRegex = new Regex(@"^(.+)(and|or)(.+)$");

        /// <summary>
        /// Helper method to create an abstract tree from a filter string. 
        /// Recursively desecends until a comparison filter string is reached.
        /// </summary>
        /// <param name="filterString"></param>
        /// <returns></returns>
        private QueryExpression ParseFilter(string filterString)
        {
            var trimmedString = filterString.Trim();
            
            // Is this a not expression? 
            Match match = _notExpressionRegex.Match(trimmedString);
            if (match.Success)
            {
                return new NotQueryExpression
                    {
                        NegatedExpression = ParseFilter(match.Groups[1].Value)
                    };
            }
            // Is this an and/or expression?
            match = _combinationRegex.Match(trimmedString);
            if (match.Success)
            {
                var operation = match.Groups[2].Value;
                if (operation.ToLower() == "and")
                {
                    return new AndQueryExpression
                        {
                            LeftSideExpression = ParseFilter(match.Groups[1].Value),
                            RightSideExpression = ParseFilter(match.Groups[3].Value)
                        };
                }
                if (operation.ToLower() == "or")
                {
                    return new OrQueryExpression
                        {
                            LeftSideExpression = ParseFilter(match.Groups[1].Value),
                            RightSideExpression = ParseFilter(match.Groups[3].Value)
                        };
                }
                throw new TableQueryParseException(String.Format("Unexpected combination operator found: {0}",operation));
            }
            // Is this an comparison expression?
            match = _comparsionRegex.Match(trimmedString);
            if (match.Success)
            {
                var operation = match.Groups[2].Value;
                QueryComparsionOperation comparsionOperation;
                switch (operation.ToLower())
                {
                    case "eq":
                        comparsionOperation = QueryComparsionOperation.Equal;
                        break;
                    case "ne":
                        comparsionOperation = QueryComparsionOperation.NotEqual;
                        break;
                    case "lt":
                        comparsionOperation = QueryComparsionOperation.LessThan;
                        break;
                    case "le":
                        comparsionOperation = QueryComparsionOperation.LessThanOrEqual;
                        break;
                    case "gt":
                        comparsionOperation = QueryComparsionOperation.GreaterThan;
                        break;
                    case "ge":
                        comparsionOperation = QueryComparsionOperation.GreaterThanOrEqual;
                        break;
                    default:
                        throw new TableQueryParseException(String.Format("Unexpected comparsion operator found: {0}", operation));
                        break;
                }
                return CreateComparsionExpression(comparsionOperation, match.Groups[1].Value, match.Groups[3].Value);
            }
            throw new TableQueryParseException("An error occured when trying to parse this expression");
        }

        /// <summary>
        /// These are the values that can appear in a comparison expression.
        /// </summary>
        private readonly Regex _binaryValueExpression = new Regex(@"^X'([0-7]+)'$");
        private readonly Regex _boolValueExpression = new Regex(@"^(true|false)$");
        private readonly Regex _dateTimeValueExpression = new Regex(@"^datetime'(.+)'$");
        private readonly Regex _doubleValueExpression = new Regex(@"^([0-9]*\.[0-9]+)$");
        private readonly Regex _guidValueExpression = new Regex(@"^guid'([0-9a-f\-]+)'$");
        private readonly Regex _intValueExpression = new Regex(@"^([0-9]+)$");
        private readonly Regex _longValueExpression = new Regex(@"^([0-9]+[lL])$");
        private readonly Regex _stringValueExpression = new Regex("^['\"](.+)['\"]$");

        private QueryExpression CreateComparsionExpression(QueryComparsionOperation comparsionOperation, string key,
                                                           string value)
        {
            string trimmedValue = value.Trim();

            // Is this a string value?
            Match match = _stringValueExpression.Match(trimmedValue);
            string matchString = match.Groups[1].Value;
            if (match.Success)
            {
                return new ComparisonExpression<string>
                    {
                        ComparisonOperation = comparsionOperation,
                        Key = key.Trim(),
                        Value = matchString
                    };
            }

            // Is this a bool value?
            match = _boolValueExpression.Match(trimmedValue);
            matchString = match.Groups[1].Value;
            if (match.Success)
            {
                bool val = matchString.ToLower() == "true";

                return new ComparisonExpression<bool>
                    {
                        ComparisonOperation = comparsionOperation,
                        Key = key.Trim(),
                        Value = val,
                    };
            }
            // Is this a int value? 
            match = _intValueExpression.Match(trimmedValue);
            matchString = match.Groups[1].Value;
            if (match.Success)
            {
                int val = int.Parse(matchString);

                return new ComparisonExpression<int>
                    {
                        ComparisonOperation = comparsionOperation,
                        Key = key.Trim(),
                        Value = val,
                    };
            }
            // Is this a long value?
            match = _longValueExpression.Match(trimmedValue);
            matchString = match.Groups[1].Value;
            if (match.Success)
            {
                long val = long.Parse(matchString);

                return new ComparisonExpression<long>
                    {
                        ComparisonOperation = comparsionOperation,
                        Key = key.Trim(),
                        Value = val,
                    };
            }
            // Is this a Guid value?
            match = _guidValueExpression.Match(trimmedValue);
            matchString = match.Groups[1].Value;
            if (match.Success)
            {
                Guid val = Guid.Parse(matchString);

                return new ComparisonExpression<Guid>
                    {
                        ComparisonOperation = comparsionOperation,
                        Key = key.Trim(),
                        Value = val,
                    };
            }

            // Is this a DateTimeOffset value?
            match = _dateTimeValueExpression.Match(trimmedValue);
            matchString = match.Groups[1].Value;
            if (match.Success)
            {
                DateTimeOffset val = DateTimeOffset.Parse(matchString);

                return new ComparisonExpression<DateTimeOffset>
                    {
                        ComparisonOperation = comparsionOperation,
                        Key = key.Trim(),
                        Value = val,
                    };
            }

            // Is this a double value?
            match = _doubleValueExpression.Match(trimmedValue);
            matchString = match.Groups[1].Value;
            if (match.Success)
            {
                double val = double.Parse(matchString);

                return new ComparisonExpression<double>
                    {
                        ComparisonOperation = comparsionOperation,
                        Key = key.Trim(),
                        Value = val,
                    };
            }
            // Is this a binary value?
            match = _binaryValueExpression.Match(trimmedValue);
            matchString = match.Groups[1].Value;
            if (match.Success)
            {
                byte[] val = new byte[matchString.Length];
                for (int i = 0; i < matchString.Length; i++)
                {
                    val[i] = (byte) (matchString[i] - '0');
                }

                return new ComparisonExpression<byte[]>
                    {
                        ComparisonOperation = comparsionOperation,
                        Key = key.Trim(),
                        Value = val,
                    };
            }
            // If none of the above really match, assume it is a string. 
            return new ComparisonExpression<string>
                {
                    ComparisonOperation = comparsionOperation,
                    Key = key.Trim(),
                    Value = value.Trim()
                };
        }
    }
}
