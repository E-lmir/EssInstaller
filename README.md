# Примечание
Настройки в config.json для CoreMessageBroker лучше не менять, т.к получилось заставить работать только билд 1.9.25<br/>
### Для установки сервисов ЛК 1.9 для Rx 4.5 как минимум следует поменять следующие пункты в config.json:<br/>
	-DBServerName,
	-DBServerUser,
	-DBServerPassword,
	-SigningCertificateThumbprint,
	-IntegrationServiceEndpoint,
	-IntegrationServiceUser,
	-IntegrationServicePassword,
	-HRRepositoryPath,
	-ESSRepositoryPath,
	-RabbitMQ.VirtualHost

 ### Для сервисов будут созданы следующие пользователи:<br/>
  	-SignServiceOperator
  	-SignServiceUser
  	-DocServiceUser
  	-EssServiceUser
Пароль для всех пользователей 11111<br/>
Поддерживается только MSSQL<br/>

# Перед установкой<br/>
Создать virtual host в RabbitMQ<br/>
Заполнить config.json<br/>
### Как начать установку сервисов<br/>
В командной строке выполнить команду <br/>
```
<Путь до приложения> <Путь до файла конфигурации>
```
Пример <br/>
```
C:\EssInstaller D:\config.json
```
# После установки <br/>
Для сервисов использующих https(по умолчанию {EssSite, EssSerivce, Identity, SignService}) привязках IIS настроить сертификат <br/>
Перезапустить пулы приложений IIS для всех вновь установленных сервисов <br/>
В проводнике Rx настроить подключение для сервисов ЛК
