# BenjaminAbt.MyDemoPlatform.Engine.Abstractions

In this namespace there are abstractions that reference other projects to be able to use our CQRS In Process Engine.

The MyDemoPlatform Engine abstractions should not have a direct dependency on the MediatR runtime, which is why we abstract the existing MediatR interfaces.

Also, this project should not have any other dependency.
