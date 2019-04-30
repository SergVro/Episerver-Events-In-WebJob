# Episerver Events In WebJob

This is a sample WebJob that subscribes on all Episerver events. The job should be deployed on an Azure Web App that runs an Episerver site in DXC environment. When publishing the WebJob set WebJob Type to Continuous. The WebJob will pick all required configuration from the Web App application settings, so no changes in the app.config needed before publshing.

See also:

https://world.episerver.com/documentation/developer-guides/CMS/event-management/Event-Management-API/
https://thisisnothing.nystrom.co.nz/2017/12/05/integration-testing-with-episerver/
https://github.com/episerver/remoteeventslistener
