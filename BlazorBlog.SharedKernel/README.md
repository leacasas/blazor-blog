## The Shared Kernel assembly

In the context of Domain Driven Design, the Shared Kernel groups elements that are shared between "bounded contexts". These contexts are where the different business rules are defined, expressed in the "ubiquituous language" of the domain; they define the scope of a certain business concern.

In practical terms, we can define the code-specific abstractions in this assembly (like base classes and interfaces), the encapsulations of the highest order, with the purpose of being shared across different bounded contexts, which would be represented by programs (applications, services, etc).