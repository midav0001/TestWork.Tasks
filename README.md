1. Для запуска проекта в файле appsettings.json (или в secrets.json) необходимо прописать connectionString к вашей бд MsSql 
2. Применить миграции: dotnet ef database update --project TestWork.Tasks.Dal/TestWork.Tasks.Dal.csproj --startup-project TestWork.Tasks.Api/TestWork.Tasks.Api.csproj --context TestWork.Tasks.Dal.Context.TaskContext --configuration Debug 20240707131622_Initial

Описание проекта
 - Перед прикреплением файла к задаче необходимо его загрузить с помощью метода в Upload в FileStorageController. Полученный ИД файла прикреплять к задаче.
 - Для динамического отображения полей существует ручка которая присылает метаданные(task/metadata) на фронт, по которым он будет отрисовывать необходимые поля 
 - В теле Задачи будет возвращаться адрес по которому можно скачать файл из ФХ