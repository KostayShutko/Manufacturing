> **This project is a work imitation of a factory. The main flow is the delivery of material to the material warehouse, transportation of material to processing machines, processing and production of products, transportation of products to the product warehouse, shipment of products.Production management is handled by the orchestrator, who runs the saga and monitors success, and in case of failure makes compensation.The project is developed as a distributed system on microservices using a message bus. RabbitMQ is a message broker, Masstransit is used for process orchestration and transactions.The project is deployed on Google Cloud using Docker containers and Kubernetes. The github actions triggers a docker image build, image push to Google Container Registry(GCR) and deployment to Google Kubernetes Engine(GKE).** 🚀

## Project architecture
<div align="center" style="margin-bottom:20px">
  <img src="https://github.com/KostayShutko/Manufacturing/assets/26852817/21428027-3f7b-4768-ab11-820aa31f9e3e"/>
</div>


`Materials Warehouse Microservice` - It's used to receive and store material in a warehouse. The material is reserved by the orchestrator and then moved to the processing machine.

`Products Warehouse Microservice` - It's used to store finished products and shipping. The product is moved from the processing machine and stored in the warehouse until a shipment request is received.

`Transportations Microservice` - It's used to move materials from the materials warehouse to the processing machines and after processing the product is moved from the processing machines to the products warehouse.

`Processing Machines Microservice` - It's used to produce a product from a material.

`Workflow Orchestrator Microservice` - It's used for managing the process of producing products. First, the orchestrator reserves a material and a place in the products warehouse, then if the both reservations are successful, the material is transported to the processing machine, then the orchestrator sends command with instructions on what product to produce on the processing machine, then producing a product, then the product is transported to the products warehouse, at this stage the process is completed and the product awaits shipment. The orchestrator tracks all events and change state of the process. The orchestrator also tracks errors and business exceptions, in this case the orchestrator trigger the compensation.
 
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
