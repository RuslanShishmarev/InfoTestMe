# InfoTestMe
App for courses and tests

# Идея:
Приложение для прохождения курсов и тестирования от преподавателей на телефоне.
Пользователи могут найти интересующего лектора и выбрать любой из его продуктов (курс, тест).
Курс содержит в себе темы. Темы делятся на страницы. Страницы могут содержать в себе картинки, текстовое описание и голосовое сопровождение. 
Тестирование содержит темы и вопросы. Вопросы могут быть с вариантами ответов и без. В конце показывается результат. Вся функциональность доступна через приложение на смартфоне
Для авторов. Есть возможность загрузить курс и тест. Просматривать результаты учеников, смотреть посещаемость. Вся функциональность для авторов будет доступна через web приложение
Название: InfoTestMe

# Сущности.
1.	Пользователь:
1.1.	Свойства:
1.1.1.	Имя
1.1.2.	Фамилия
1.1.3.	Почта – логин
1.1.4.	Дата регистрации
1.1.5.	Дата последнего визита
1.1.6.	Курсы - id
1.1.7.	Тесты – id 
1.2.	Методы – возможности:
1.2.1.	Записаться на курс
1.2.2.	Пройти тестирование
1.2.3.	Просмотреть результаты
2.	Автор
2.1.	Свойства:
2.1.1.	Имя
2.1.2.	Фамилия
2.1.3.	Почта - логин 
2.1.4.	Дата регистрации
2.1.5.	Дата последнего визита
2.1.6.	Курсы – id
2.1.7.	Тесты – id
2.1.8.	Ключевые слова
2.1.9.	Описание
2.2.	Методы – возможности:
2.2.1.	Создать курс
2.2.2.	Изменить курс
2.2.3.	Создать тест
2.2.4.	Изменить тест
2.2.5.	Просмотреть аналитику курса (ученики, прогресс учеников)
2.2.6.	Просмотреть аналитику теста (ученики, результаты учеников)


3.	Курс
3.1.	Свойства:
3.1.1.	Название
3.1.2.	Описание
3.1.3.	Картинка
3.1.4.	Темы
3.1.4.1.	Название
3.1.4.2.	Страницы
3.1.4.2.1.	Название
3.1.4.2.2.	Блоки
3.1.4.2.2.1.	Картинка
3.1.4.2.2.2.	Описание
3.1.4.2.2.3.	Ссылка
3.1.4.2.3.	Аудио запись
4.	Тест 	
4.1.	Свойства:
4.1.1.	Название
4.1.2.	Описание
4.1.3.	Картинка
4.1.4.	Вопросы
4.1.4.1.	Тело вопроса
4.1.4.2.	Количество балов
4.1.4.3.	Ответы
4.1.4.3.1.	Тело ответа
4.1.4.3.2.	Верно/не верно


# API
## Общий
1.	Получение токена авторизации – все запросы требуют bearer token 
## Для пользователей
2.	Регистрация как юзер – все свойства для юзера и валидный логин (почта). 
3.	Получить информацию по пользователю – все свойства для юзера, кроме пароля
4.	Получить информацию по автору – все свойства автора, кроме пароля
5.	Поиск автора по имени или ключевому слову – выдается список авторов (фото + имя)
6.	Записаться на курс – отправляется id текущего пользователя и id выбранного курса
7.	Начать тестирование – отправляется id текущего пользователя и id выбранного теста с результатом 0 балов.
8.	Завершить тестирование – отправить результаты теста в виде id вопросов и id ответ. Производится расчет результата и записывается в базу.


 
## Для авторов
9.	Регистрация как автор – все свойства для автора и валидный логин (почта)
10.	Создать/редактировать тест – отправляется id автора, название, описание, картинка. Возвращается id теста.
11.	Создать/редактировать вопрос – отправляется id автора, id теста, тело вопроса, список ответов (тело ответа, да/нет), количество балов от 1 до 10.
12.	Получить результаты теста – отправляется id пользователя и id теста возвращается список вопросов с вариантами ответов пользователя со статусом верно или не верно. Так же возвращается общий результат за тест.
13.	Получить аналитику теста – отправляется id преподавателя и id теста. Возвращается список пользователей (почта, имя) с общим результатом и дата прохождения
14.	Создать/редактировать курс – отправляется id автора, название, описание и картинка курса. Возвращается id курса.
15.	Создать/редактировать тему – отправляется id автора, id курса, название темы. Возвращается id темы.
16.	Создать/редактировать станицу для темы – отправляется id автора, id курса, id темы, название, список из блоков
17.	Получить аналитику курса – отправляется id преподавателя, id курса. Возвращается список пользователей (почта, имя).

## Локальная база для пользователей
В локальной db будет сохраняться курс по желанию для возможности прохождения оффлайн.
Так же будет храниться кэш изображений и информация по текущему пользователю
