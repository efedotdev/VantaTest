# VantaTest
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084309" src="https://github.com/user-attachments/assets/cd966c7b-adb8-43ee-a169-4d6699faff00" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084319" src="https://github.com/user-attachments/assets/a08188f3-f54d-4944-b932-e42e4ab00e58" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084335" src="https://github.com/user-attachments/assets/6b56c565-933b-4c2c-aad1-98fd9bd312d9" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084332" src="https://github.com/user-attachments/assets/2f7bdc9c-fbed-431e-880e-2fb3f7192cea" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084325" src="https://github.com/user-attachments/assets/05aa6273-93fc-42d6-9b92-da35eac0af8b" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084356" src="https://github.com/user-attachments/assets/eaeef893-cde6-45a2-850e-e4514257ccc1" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084408" src="https://github.com/user-attachments/assets/94cd1493-bcd6-4cd5-9148-4133b125860c" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084434" src="https://github.com/user-attachments/assets/fe864bf3-8dca-4e93-947b-0ad395f2ff9e" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084441" src="https://github.com/user-attachments/assets/e61f31a5-a40c-4617-bc8c-9029a5d78988" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084450" src="https://github.com/user-attachments/assets/2b85e6b4-91cf-41f1-ad97-fb08e8b26d51" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084502" src="https://github.com/user-attachments/assets/8b9bc2d4-61d9-4302-ba02-5ccfc61b52c1" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084512" src="https://github.com/user-attachments/assets/f3c04dc4-d628-470e-a35b-46880a1567cf" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084527" src="https://github.com/user-attachments/assets/4b4e7303-bcc3-4ab3-9938-351542598a6f" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084537" src="https://github.com/user-attachments/assets/d30337cd-96ff-4137-aa4d-40f4c3e2a3d5" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084542" src="https://github.com/user-attachments/assets/8d6bf042-e1bc-4d63-a9f9-4ef1dec590c0" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084549" src="https://github.com/user-attachments/assets/0ed31268-9ec2-4413-8329-d8917f9f4ed0" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084553" src="https://github.com/user-attachments/assets/f555c0bc-75ef-4de8-bb26-e9a0efea2d10" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084559" src="https://github.com/user-attachments/assets/e8265419-3150-4f40-a10d-4ef560d9a6fa" />
<img width="2560" height="1392" alt="Ekran görüntüsü 2026-06-22 084616" src="https://github.com/user-attachments/assets/cba6f620-6b7d-4b5d-a435-f50d1493654f" />


## About this solution

This is a layered startup solution based on [Domain Driven Design (DDD)](https://abp.io/docs/latest/framework/architecture/domain-driven-design) practises. All the fundamental ABP modules are already installed. Check the [Application Startup Template](https://abp.io/docs/latest/solution-templates/layered-web-application) documentation for more info.

### Pre-requirements

* [.NET10.0+ SDK](https://dotnet.microsoft.com/download/dotnet)
* [Node v18 or 20](https://nodejs.org/en)

### Configurations

The solution comes with a default configuration that works out of the box. However, you may consider to change the following configuration before running your solution:

* Check the `ConnectionStrings` in `appsettings.json` files under the `VantaTest.Web` and `VantaTest.DbMigrator` projects and change it if you need.

### Before running the application

* Run `abp install-libs` command on your solution folder to install client-side package dependencies. This step is automatically done when you create a new solution, if you didn't especially disabled it. However, you should run it yourself if you have first cloned this solution from your source control, or added a new client-side package dependency to your solution.
* Run `VantaTest.DbMigrator` to create the initial database. This step is also automatically done when you create a new solution, if you didn't especially disabled it. This should be done in the first run. It is also needed if a new database migration is added to the solution later.

#### Generating a Signing Certificate

In the production environment, you need to use a production signing certificate. ABP Framework sets up signing and encryption certificates in your application and expects an `openiddict.pfx` file in your application.

To generate a signing certificate, you can use the following command:

```bash
dotnet dev-certs https -v -ep openiddict.pfx -p c42e417d-60cd-4d49-913e-ee9d31da6737
```

> `c42e417d-60cd-4d49-913e-ee9d31da6737` is the password of the certificate, you can change it to any password you want.

It is recommended to use **two** RSA certificates, distinct from the certificate(s) used for HTTPS: one for encryption, one for signing.

For more information, please refer to: [OpenIddict Certificate Configuration](https://documentation.openiddict.com/configuration/encryption-and-signing-credentials.html#registering-a-certificate-recommended-for-production-ready-scenarios)

> Also, see the [Configuring OpenIddict](https://abp.io/docs/latest/Deployment/Configuring-OpenIddict#production-environment) documentation for more information.

### Solution structure

This is a layered monolith application that consists of the following applications:

* `VantaTest.DbMigrator`: A console application which applies the migrations and also seeds the initial data. It is useful on development as well as on production environment.
* `VantaTest.Web`: ASP.NET Core MVC / Razor Pages application that is the essential web application of the solution.





## Deploying the application

Deploying an ABP application follows the same process as deploying any .NET or ASP.NET Core application. However, there are important considerations to keep in mind. For detailed guidance, refer to ABP's [deployment documentation](https://abp.io/docs/latest/Deployment/Index).

### Additional resources

You can see the following resources to learn more about your solution and the ABP Framework:

* [Web Application Development Tutorial](https://abp.io/docs/latest/tutorials/book-store/part-1)
* [Application Startup Template](https://abp.io/docs/latest/startup-templates/application/index)
