#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG VERSION=1.0.0

COPY Tweetbook/Tweetbook.csproj Tweetbook_build/
COPY Tweetbook/appsettings.json Tweetbook_build/
COPY Tweetbook.Contracts/Tweetbook.Contracts.csproj /Tweetbook.Contracts/
#COPY Tweetbook.IntegrationTests/Tweetbook.IntegrationTests.csproj /Tweetbook.IntegrationTests/
#COPY Tweetbook.Sdk/Tweetbook.Sdk.csproj /Tweetbook.Sdk/
#COPY Tweetbook.Sdk.Sample/Tweetbook.Sdk.Sample.csproj /Tweetbook.Sdk.Sample/
RUN dotnet restore ./Tweetbook_build/Tweetbook.csproj
COPY . /Tweetbook_build/
WORKDIR /Tweetbook_build/
#RUN dotnet build "Tweetbook.csproj" -c %BUILD_CONFIGURATION% -o /app/Tweetbook_build 

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Tweetbook.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false:Version=$VERSION

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tweetbook.dll"]

#FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
#
#ARG BUILDCONFIG=RELEASE
#ARG VERSION=1.0.0
#
#COPY *.sln ./
#COPY Tweetbook/Tweetbook.csproj /build/
#COPY Tweetbook.Contracts/Tweetbook.Contracts.csproj /Tweetbook.Contracts/
##COPY Tweetbook.IntegrationTests/Tweetbook.IntegrationTests.csproj /Tweetbook.IntegrationTests/
##COPY Tweetbook.Sdk/Tweetbook.Sdk.csproj /Tweetbook.Sdk/
##COPY Tweetbook.Sdk.Sample/Tweetbook.Sdk.Sample.csproj /Tweetbook.Sdk.Sample/
#
#RUN dotnet restore ./build/Tweetbook.csproj
#
#COPY . ./build/
#WORKDIR /build/
#
#RUN dotnet publish ./Tweetbook.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0
#WORKDIR /app
#
#COPY --from=build /build/out .
#
#ENTRYPOINT ["dotnet", "Tweetbook.dll"] 