Проект WEB портала для фирмы, занимающейся ремонтом компьютеров и оргтехники.

 ## **Backend**:

В проекте используется микросервисная архитектура с использованием шлюза ocelot. Испльзуемые библиотеки и технологии: Entity Framework Core и EntityFrameworkCore.DataAccess (https://github.com/ffernandolima/ef-core-data-access/tree/ef-core-7) для работы с базой данных PostgreSQL; Refit (https://github.com/reactiveui/refit) - типобезопасная REST библиотека для .NET; AutoMapper (https://github.com/AutoMapper/AutoMapper) - библиотека для сопоставления одних объектов с другими; FluentValidation (https://github.com/FluentValidation/FluentValidation) - библиотека для создания строго типизированных правил проверки. Контейнеризация микросервисов происходит посредством программного обеспечения - docker.
## **Frontend:**
При написании проекта использовались следующие технологии: адаптивный и легковесный CSS фреймворк Bulma (https://bulma.io/); библиотека JQuery (https://jquery.com/); язык программирования TypeScript (https://www.typescriptlang.org/).
В текущей версии происходи постепенный переход от использования JavaScript и замены его на веи-платформу Blazor. В проекте используется библиотека компонентов Blazorise
