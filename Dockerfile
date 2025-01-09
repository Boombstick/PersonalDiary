#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Используем базовый образ SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-stage

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем файл решения и файлы проектов, исключая тестовый проект
COPY PersonalDiary.sln ./ 
COPY PersonalDiary.Api/PersonalDiary.Api.csproj ./PersonalDiary.Api/
COPY PersonalDiary.Domain/PersonalDiary.Domain.csproj ./PersonalDiary.Domain/
COPY PersonalDiary.Application/PersonalDiary.Application.csproj ./PersonalDiary.Application/
COPY PersonalDiary.Persistence/PersonalDiary.Persistence.csproj ./PersonalDiary.Persistence/

# Устанавливаем параметры NuGet, чтобы пропустить отсутствующие проекты
RUN dotnet restore --ignore-failed-sources

# Копируем остальные файлы
COPY . ./ 

# Сборка и публикация только для API проекта
RUN dotnet publish PersonalDiary.Api -c Release -o /publish

# Используем базовый образ Runtime для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime-stage

# Копируем опубликованные файлы
COPY --from=build-stage /publish /app

# Устанавливаем рабочую директорию
WORKDIR /app

# Указываем порт
EXPOSE 80

# Запускаем приложение
ENTRYPOINT ["dotnet", "PersonalDiary.Api.dll"]
