> **This project is a work imitation of a factory. The main flow is the delivery of material to the material warehouse, transportation of material to processing machines, processing and production of products, transportation of products to the product warehouse, shipment of products.Production management is handled by the orchestrator, who runs the saga and monitors success, and in case of failure makes compensation.The project is developed as a distributed system on microservices using a message bus. RabbitMQ is a message broker, Masstransit is used for process orchestration and transactions.The project is deployed on Google Cloud using Docker containers and Kubernetes. The github actions triggers a docker image build, image push to Google Container Registry(GCR) and deployment to Google Kubernetes Engine(GKE).** 🚀

## Project architecture
<div align="center" style="margin-bottom:20px">
  <img src="https://github.com/KostayShutko/Manufacturing/assets/26852817/21428027-3f7b-4768-ab11-820aa31f9e3e"/>
</div>


`Materials Warehouse Microservice` - It's used for 
`Products Warehouse Microservice` - It's used for 
`Transportations Microservice` - It's used for 
`Processing Machines Microservice` - It's used for 
`Workflow Orchestrator Microservice` - It's used for 
