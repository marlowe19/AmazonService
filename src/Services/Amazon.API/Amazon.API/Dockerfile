FROM microsoft/dotnet:nanoserver-runtime
LABEL name "Amazon.API"
ARG source
WORKDIR /
ENV ASPNETCORE_URLS http://0.0.0.0:5001
EXPOSE 5001
COPY ${source:-obj/Release/PublishOutput} .
