FROM microsoft/dotnet:1.1-sdk-msbuild-nanoserver
LABEL name "amazon-mvc"
WORKDIR / 
ARG source=.
ENV ASPNETCORE_URLS http://0.0.0.0:5004
EXPOSE 5003
COPY obj/Release/PublishOutput .

