# GraphQLWithHotChocolate

This project is an implementation of CQRS (Command Query Responsibility Segregation), Event sourcing, Unit of Work, Repository patterns, and GraphQL using .NET Core.

## Introduction

The GraphQLWithHotChocolate project aims to showcase the integration of various architectural patterns and technologies within a .NET Core application. By leveraging CQRS, Event sourcing, Unit of Work, Repository patterns, and GraphQL, the project provides a robust and flexible foundation for building scalable and maintainable applications.

## Features

The project includes the following features:

- **CQRS (Command Query Responsibility Segregation):** The CQRS pattern is implemented to separate read and write operations, allowing for more efficient query handling and scalability.

- **Event sourcing:** Event sourcing is utilized to capture and store all changes to the application's state as a sequence of events. This approach enables easy replaying of events and auditability of system behavior.

- **Unit of Work:** The Unit of Work pattern is employed to manage transactional operations and ensure consistency when interacting with the data layer.

- **Repository patterns:** Repositories are used to abstract the data access layer and provide a consistent interface for querying and persisting data.

- **GraphQL:** The project integrates GraphQL using the Hot Chocolate library, which offers a powerful and flexible approach to querying and manipulating data. GraphQL enables clients to request specific data structures, reducing over-fetching and under-fetching issues commonly associated with REST APIs.

## Getting Started

To get started with the GraphQLWithHotChocolate project, follow these steps:

1. Clone the repository:

```shell
git clone https://github.com/your-username/GraphQLWithHotChocolate.git
```

2. Navigate to the project directory:

```shell
cd GraphQLWithHotChocolate
```

3. Build the project using the .NET CLI:

```shell
dotnet build
```

4. Run the application:

```shell
dotnet run --project .\Api
```

5. Open your preferred web browser and access the GraphQL endpoint:

```
http://localhost:5066/graphql
```

Please note that the application is also listening on the following HTTPS port:

```
https://localhost:7066
```

## Configuration

The project's configuration can be customized through the following settings:

- `appsettings.json`: Contains general application settings such as the database connection string, logging configuration, and other environment-specific configurations.

## Contributing

Contributions to the GraphQLWithHotChocolate project are welcome and encouraged. If you would like to contribute, please follow these steps:

1. Fork the repository.

2. Create a new branch for your feature or bug fix:

```shell
git checkout -b feature/your-feature-name
```

3. Commit your changes and push them to your forked repository.

4. Submit a pull request describing your changes and their benefits.

## License

The GraphQLWithHotChocolate project is licensed under the [MIT License](LICENSE).

## Acknowledgements

I would like to express our gratitude to the following open-source projects and communities:

- [.NET Core](https://dotnet.microsoft.com/)
- [Hot Chocolate](https://hotchocolate.io/)

Their contributions and efforts have greatly facilitated the development of this project.

## Contact

If you have any questions, suggestions, or feedback, please feel free to contact me at sandhu.manpreet366@gmail.com.

Thank you for your interest in the GraphQLWithHotChocolate project!
