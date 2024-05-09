> **This project simulates a factory workflow. The main process involves delivering materials to the warehouse, transportation them to processing machines, processing materials and creating products, transportation of finished products to the product warehouse for shipment. Production management is overseen by an orchestrator that coordinates the entire workflow, monitors success, and provides compensation in case of failures. The project is designed as a distributed system using microservices and a message bus. RabbitMQ is responsible for sending messages and MassTransit handles process orchestration and transactions. The project is deployed on Google Cloud using Docker containers and Kubernetes. GitHub Actions trigger the build of Docker images, which are then pushed to Google Container Registry (GCR) and deployed on Google Kubernetes Engine (GKE).** 🚀

## Project architecture
<div align="center" style="margin-bottom:20px">
  <img src="https://github.com/KostayShutko/Manufacturing/assets/26852817/21428027-3f7b-4768-ab11-820aa31f9e3e"/>
</div>


`The Materials Warehouse Microservice` is responsible for receiving and storing materials in a warehouse. The material is reserved by the orchestrator and then moved to the processing machine.

`The Products Warehouse Microservice` is responsible for storing finished products and shipping them. The product is moved from the processing machine and stored in the warehouse until a shipment request is received.

`The Transportations Microservice` facilitates the movement of materials from the materials warehouse to the processing machines. Once processing is complete, the product is then moved from the processing machines to the products warehouse.

`The Processing Machines Microservice` is responsible for transforming materials into finished products.

`The Workflow Orchestrator Microservice` plays a crucial role in managing the production process. First, the orchestrator begins by reserving both the necessary material and a spot in the products warehouse. If both reservations are successful, the reserved material is then transported from the materials warehouse to the processing machine. The orchestrator sends commands to the processing machine, specifying what product needs to be produced. The processing machine produces the desired product based on the provided instructions. Once the product is finished, it is transported from the processing machine to the products warehouse. At this stage, the production process is considered complete. The product is stored in the warehouse and ready for shipment. The orchestrator tracks all events and change state of the process. The orchestrator also tracks errors and business exceptions, the orchestrator triggers compensation mechanisms. These actions help maintain consistency and resolve any issues that arise during production.
 
## Tech Stack
- .Net 6
- DDD
- CQRS
- MS SQL
- EF Core
- MediatR
- AutoMapper
- FluentValidation
- Global Error Handling
- Specification Pattern
- Result Pattern
- Auditable Entities
- Event-Driven Architecture
- Distributed Transactions
- MassTransit
- RabbitMQ
- Saga Pattern
- Workflow Orchestrator
- Docker
- GitHub Actions
- Kubernetes
- Google Container Registry
- Google Kubernetes Engine

## Use Cases
