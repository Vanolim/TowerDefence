# TowerDefence
 
Классический TowerDefence с элементами RPG. Суть заключается в прохождении уровней с волнами врагов. Для прохождения уровня нужно грамотно продумать свою экономику и грамотно рассположить защитные башни.

# Основные особенности проекта:
1) Игра подходит для игры на пк и для игры на андройде без изменения кода (на андройде активируется джойстик для управления)
2) Удобное добавление новых уровней. Новый уровень автоматически встривается в систему игры:
Пример: https://youtu.be/M1v_dbNAHcM
3) Все параметры для нового уровня настраиваются в кастомном редакторе в одном месте: волны врагов, доступные типы башен на уровне, экономика уровня.
Пример: https://youtu.be/j4egsZCg1HI
4) Все основные данные для игры (данные врагов, данные башен, уровней и т.д.) хранятся в ScriptableObject файлах.
5) Архитектура проекта построена на основе машины состояний с одной точкой входу (Bootstrapper). Смена уровней и загрузка главного меню происходит с помощью смены состояний: 
![image]<img src="https://user-images.githubusercontent.com/60060770/179183461-ca7eaf0b-5ade-49f5-a2b3-d9da0ef2e2ee.png" width="800" height="800">
6) При иницализации проекта проиходит подгрузка сервисов проекта, которые находятся в DontDestroyOnLoad объекте. Этот объект будет переходить в каждую активную сцену и все сервисы в нем будут работать непрерывно на протяжении всей игры

# Демострация проекта:
![1](https://user-images.githubusercontent.com/60060770/179187798-05c3a75c-a37c-4fe9-a0e6-635dbcf6dec3.png)
![2](https://user-images.githubusercontent.com/60060770/179187813-2a153ab4-ad65-479a-b31a-7cf10cdcee03.png)
![3](https://user-images.githubusercontent.com/60060770/179187823-b5269e1e-17be-4251-9014-eac6979b22ae.png)

# Прохождение уровней:
1) Прохождение первого уровня - https://youtu.be/B8zXc2LvDtY
2) Прохождение второго уровня - https://youtu.be/zxyIsLu7zPM

# Плагины, использованные в проекте:
1) DOTween
2) TextMeshPro
