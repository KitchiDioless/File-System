# Цель

Разработать приложение для взаимодействия и управления файловой системой.

# Функциональные требования

- Навигация по дереву файловой системы
- Просмотр содержимого каталога в консоли
- Просмотр содержимого файлов в консоли
- Перемещение файлов
- Копирование файлов
- Удаление файлов
- Переименование файлов
- Консольный механизм взаимодействия с приложением
- Реализация операций для локальной файловой системы

# Не функциональные требования

- Система поддерживает взаимодействие посредством консольных команд, имеющих флаги.
- Система поддерживает возможность расширения параметров консольных команд.
- Вывод содержимого каталога параметризован глубиной выборки (значение по умолчанию - 1)
- Вывод системного каталога в виде дерева.
- Параметры выводимого дерева (символы обозначающие файл, папку, символы используемые для отступов)
  программно параметризуемые.

# Семантика команд

- connect [Address] [-m Mode] \
  Address - абсолютный путь в подключаемой файловой системе \
  Mode - режим файловой системы
- disconnect \
  Отключается от файловой системы
- tree goto [**Path**] \
  **Path** - относительный или абсолютный путь до каталога в файловой системе
- tree list {-d **Depth**} \
  **Depth** - параметр, определяющий глубину выборки, должен объявляться флагом `-d`
- file show [**Path**] {-m **Mode**} \
  **Path** - относительный или абсолютный путь до файла \
  **Mode** - режим вывода файла
- file move [**SourcePath**] [**DestinationPath**] \
  **SourcePath** - относительный или абсолютный путь до перемещаемого файла \
  **DestinationPath** - относительный или абсолютный путь до директории, куда файл должен быть перемещён
- file copy [**SourcePath**] [**DestinationPath**] \
  **SourcePath** - относительный или абсолютный путь до копируемого файла \
  **DestinationPath** - относительный или абсолютный путь до директории, куда файл должен быть скопирован
- file delete [**Path**] \
  **Path** - относительный или абсолютный путь до удаляемого файла
- file rename [**Path**] [**Name**] \
  **Path** - относительный или абсолютный путь до изменяемого файла \
  **Name** - новое имя файла
