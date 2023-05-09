# GCP Cloud Run with .NET (C#)

使用 VSCode remote-container 作為開發工具

## GCP Commands

### build

`
gcloud builds submit --tag gcr.io/[projectname]/[service-name]
`

### deploy

`
gcloud run deploy cloud-csharp --image gcr.io [projectname]/[service-name]
`

### deploty from source

```gcloud run deploy --source .```

### Run Locally

build

`docker build -t cloud-csharp .`

run

`docker run --rm -p 8080:8080 --name [name] -e PORT='8080' cloud-csharp`