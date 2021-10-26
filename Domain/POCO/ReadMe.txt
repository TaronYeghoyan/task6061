(Plain Old CLR Object)

Clean C# Code

First of all, DTO and Value Object represent different concepts and can’t be used interchangeably.
On the other hand, POCO is a superset for DTO and Value Object:
In other words, Value Object and DTO shouldn’t inherit any heavy-weight enterprise components and thus they are POCO. 
At the same time, POCO is a wider set: 
it can be Value Object, Entity, DTO or any other class you might create as long as it doesn’t inherit complexity accidental to your domain.