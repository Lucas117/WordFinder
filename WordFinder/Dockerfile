FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY WordFinder/WordFinder.csproj WordFinder/
COPY WordFinder.Utils/WordFinder.Utils.csproj WordFinder.Utils/
COPY WordFinder.Validation/WordFinder.Validation.csproj WordFinder.Validation/
COPY WordFinder.Strategy/WordFinder.Strategy.csproj WordFinder.Strategy/
RUN dotnet restore WordFinder/WordFinder.csproj
COPY . .
WORKDIR /src/WordFinder
RUN dotnet build WordFinder.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WordFinder.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WordFinder.dll"]
