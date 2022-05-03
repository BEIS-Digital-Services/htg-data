FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

COPY ["Beis.Htg.VendorSme.Database/Beis.Htg.VendorSme.Database.csproj","Beis.Htg.VendorSme.Database/"]
RUN dotnet restore "Beis.Htg.VendorSme.Database/Beis.Htg.VendorSme.Database.csproj"
COPY . .
WORKDIR "/src/Beis.Htg.VendorSme.Database"
RUN dotnet publish "Beis.Htg.VendorSme.Database.csproj" -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Beis.Htg.VendorSme.Database.dll"]