# The infrastructure assembly

This is the assembly that should contain the external dependencies, implementing interfaces defined within the Core assembly.

This assembly can include:
- Repositories and cached repositories
- HTTP Clients
- File System I/O
- Email or messaging clients
- Service references
- DbContext
- Other types of storage access
- Other services and interfaces that cannot be considered part of the domain and only live within the infrastructure assembly