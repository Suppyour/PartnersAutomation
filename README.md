# 🏪 Проект PartnersAutomation
✨ **Проектный практикум** ✨

Этот проект использует **Docker Compose** для настройки и запуска приложения с базой данных PostgreSQL.

## Установка и запуск проекта для Frontend'a

### 🌟 1. Скачать DockerDesktop и поставь на фон.

![Image](https://github.com/user-attachments/assets/e0afb503-84e6-4bb3-bd94-0a1327c71402)

### 🌟 2. Запускай compose up.bat 

![Image](https://github.com/user-attachments/assets/c29ec597-5134-49a8-90bd-04a15482cf47)

### 🌟 3. Важно. В адресную строку браузера:
```
http://localhost:8080/swagger/index.html
```
# ____________________________________________________________________________


# 🔧 Для Backend'a


## 🐳 Работа с Docker

### 🔧 1. Открыть с помощью Visual Studio Code -> docker-compose.yml 
```
cd Users\mpors\Desktop\PartnersAutomation\Backend
cd Users\*\*\PartnersAutomation\Backend
```
### 🔧 2. Проверь что установлен Docker Desktop
```
docker-compose --version
```
### 🔧 3. Основные команды по работе с Docker
```
docker-compose down
docker-compose down -v (удаление записей БД)
docker-compose up --build
```
### 💡 4. Основные команды по работе с EF Core 💡
```
dotnet ef migrations add <НазваниеМиграции>
dotnet ef database update
dotnet ef migrations remove
dotnet ef migrations list
```
