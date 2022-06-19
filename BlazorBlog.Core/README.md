## The Core Assembly

Center of the Clean Architecture design. All other projects will depend on it. It should have very few external dependencies. Things that one would find in the Core project would be:

- **Entities** : *Things that have an ID, that are usually stored in a data layer and are operated through repositories.*
- **Value Objects** : *Things that are comparable just by looking at their properties. Their value its their whole purpose, like a color or a date; if the value changes, then the object is not the same. Enums could be considered value objects (Domain-specific enumerations).*
- **Aggregates** : *This would be a thing that encapsulate several others that may hold some relation to one another (like a purchasing order containing line items).*
- **Interfaces** : *The contracts of the system, this determines how the things that operate the Domain model should be defined, like the repositories, factories, etc. These are the 'ports' where dependencies plug into.*
- **Domain Events** : *State changes that are published for consumers. They are specific to the objects of the domain. They would specify all the ways that entities, value objects, aggregates, change state.*
- **Event Handlers** : *Domain event handlers could be defined in this layer too. Although consumers of the Domain events from other layers, like Applications, could define their own way to handle these events; a common interface or abstraction could be defined here.*
- **Domain Services** : *Logic that can't be encapsulated into any particular domain object but it's relevant to the domain. Domain-specific business logic that is computed with mostly domain objects can be implemented in these services.* 
- **Specifications** : *A query-logic taken out of other common places (like repositories). They can be thought of familiar and often used querying criteria; they are a list of properties of an object that's being queried that are needed for something.*
- **Custom Guards** : *Pattern to "fail fast", by checking for the invalid inputs it is "guarding against" and that should not happen under normal circumstances*.