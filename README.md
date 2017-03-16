# AzureMock

A older project for in memory mocking of Azure Table and Blob Services.

This project hasn't been validated against the latest versions of the Azure Table and Blob Services, 
but it shows some interesting coding in terms of simple parsing via regular expressions
and the use of dynamically created lambdas to implement complex queries against the 
mock in memory table collection. 

Much work is needed to make this a complete in-memory mock service. It should also be noted that
Microsoft provides local emulator support for both table and blob services. The project was motiviated
to see if a useful set of interfaces for the service could be created and mock be used for unit testing
versus using the local emulator. 

As always, the best pattern is to isolate Azure Table and Blob presistence via the repository pattern,
and to use mocks of those repositories. However, the repostories themselves need to be tested, and a
useful in memory mock support would be very useful, versus having to install the emulators on a CI
or dedicating Azure resources for build servers.






