
Пример работы:

https://github.com/user-attachments/assets/4900a438-4b51-4c1e-b287-ed78c4b254d1

<!-- https://github.com/user-attachments/assets/789a3d79-c661-4a05-ba21-d4203730e9a6-->
<!-- https://github.com/user-attachments/assets/c9df9f43-e60a-488f-a1b7-dce9edbecf1d -->

## В коде точка входа: [Assets/_Project/Core/ClockModel.cs](https://github.com/gggittt/ClockHttp/blob/main/Assets/_Project/Core/ClockModel.cs)

## Реализовано:
- время с сервером сверяется при запуске.
- дальше часы локально работают самостоятельно
- время сверяется с сервером каждый час
- отображение времени в цифровом формате
- отображение времени в аналоговом формате
- ручной ввод времени
- опция выбора: строгий tick ровно раз в секунду, или же плавное перемещение стрелок (с помощью DoTween)
- некоторые оптимизации:
- - обновление времени раз в секунду, а не каждый Update
  - стрелки минут и часов обновляются раз в минуту


## Доделать:
- выставить время перетаскиванием стрелок (минутной или часовой)

## Комментарии:
- Анимации здесь простые, библиотеки анимаций не понадобились. С DoTween я работал, сам использую в проектах.
- Yandex API периодически падает, и снова работает спустя пару секунд.
- изначально я затащил в проект свои Extensions и Editor cкрипты, с которыми удобнее работать. Но проект будет работать и без них (в Core используется только 1 из Extensions). Пусть останутся как подарок гостям репозитория.

## Возможные улучшения:
- dropdown выбрать время в конкретном городе
- dropdown выбрать из какого сервиса тянуть данные
- уведомления пользователю на экране если время введено некорректно, или сервер недоступен и т.п.
- я мог бы реализовать вынос настроек в конфиги, или даже настраивать в гугл таблице. Но для тестового это избыточно

---

Поставил target platform = WebGl
Импортнул кучу своих плагинов и расширений, но обошлось без них. 
Написал решение на монобехах, т.к. удобно дебажить в инспекторе. Делал мелкие классы (чтобы было легко подменить на другую реализацию). Но можно было бы и реализовать через POCO, или обмазать всё интерфейсами. Можно уделить больше внимания неймингу. 

---

Уточнение требований. 
1) Должно ли время из инпута меняться, если хотя бы одна часть не введена (например, введены только минуты). Ничего не делать, или считать что часы и секунды = 0? 
В текущей реализации нужно эксплицитно ввести все 3 числа.
2) Должно ли время из инпута обрубаться до валидного, если введено больше границы? Если введено "70 70 70", то обрезать до "22 10 10", или же кидать ошибку или ещё как-то?
В текущей реализации я не применяю время, если любой input сверх границы.


