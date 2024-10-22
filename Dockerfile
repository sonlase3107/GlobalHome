FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY TodoApi/src/publish ./
ENV ASPCORE_URL=http://+:5000
EXPOSE 5000
ENTRYPOINT [ "dotnet","TodoApi.dll" ]

# RUN dotnet build -o /src
# RUN  dotnet publish -o /publish

# FROM  mcr.microsoft.com/dotnet/aspnet AS base
# COPY  --from=build /publish /src
# WORKDIR /src
# EXPOSE 80
# CMD ["./src"]