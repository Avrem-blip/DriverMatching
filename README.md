# Driver Matching System

## Описание проекта

Система подбора ближайших водителей такси на основе координат заказа. Реализована и протестирована на примере 4 различных алгоритмов поиска 5 ближайших водителей.

## Задача

Карта представляет собой прямоугольную сетку размером N×M, состоящую из квадратов размером 1×1. Каждый квадрат может содержать не более одного водителя.

- Координаты: 0 ≤ X < N, 0 ≤ Y < M
- Каждый водитель имеет уникальный идентификатор
- Расстояние рассчитывается по формуле Евклида

## Реализованные алгоритмы

### 1. Simple Sorting Algorithm
- **Временная сложность:** O(n log n)
- **Пространственная сложность:** O(n)
- **Описание:** Базовая сортировка всех водителей по расстоянию и выбор первых 5

### 2. Heap-Based Algorithm
- **Временная сложность:** O(n log k)
- **Пространственная сложность:** O(k)
- **Описание:** Использует приоритетную очередь (максимальную кучу) для эффективного поиска k ближайших элементов

### 3. QuickSelect Algorithm
- **Временная сложность:** O(n) в среднем, O(n²) в худшем случае
- **Пространственная сложность:** O(k) + O(log n) для рекурсии
- **Описание:** Использует метод разделения (partition) для поиска k-ого элемента

### 4. Partial Sort Algorithm
- **Временная сложность:** O(n log k)
- **Пространственная сложность:** O(n)
- **Описание:** LINQ-based подход с использованием OrderBy и Take

## Структура проекта

```
DriverMatching.sln
├── DriverMatching/
│   ├── Models/
│   │   ├── Driver.cs
│   │   ├── Order.cs
│   │   └── DriverDistance.cs
│   ├── Algorithms/
│   │   ├── IDriverMatchingAlgorithm.cs
│   │   ├── SimpleSortingAlgorithm.cs
│   │   ├── HeapBasedAlgorithm.cs
│   │   ├── QuickSelectAlgorithm.cs
│   │   └── PartialSortAlgorithm.cs
│   └── Benchmarks/
│       └── DriverMatchingBenchmarks.cs
├── DriverMatching.Tests/
│   ├── SimpleSortingAlgorithmTests.cs
│   ├── HeapBasedAlgorithmTests.cs
│   ├── QuickSelectAlgorithmTests.cs
│   └── PartialSortAlgorithmTests.cs
├── .gitignore
└── README.md
```

## Требования

- .NET 6.0
- C# 10
- Visual Studio 2022

## Зависимости

- **BenchmarkDotNet** - для измерения производительности алгоритмов
- **NUnit** - для модульного тестирования

## Как использовать

### 1. Клонирование репозитория

```bash
git clone https://github.com/Avrem-blip/DriverMatching.git
cd DriverMatching
```

### 2. Открытие в Visual Studio

```bash
start DriverMatching.sln
```

### 3. Запуск тестов

В Visual Studio:
- **Тест** → **Запустить все тесты** (Ctrl + R, A)

В терминале:
```bash
dotnet test
```

Ожидаемый результат:
```
Test Run Successful.
Total tests: 23
Passed: 23
Failed: 0
```

### 4. Запуск бенчмарков

```bash
cd DriverMatching
dotnet run -c Release
```

Бенчмарк протестирует все 4 алгоритма с количеством водителей: 1,000, 10,000, 100,000

## Результаты тестирования

Все 23 теста успешно пройдены:
- SimpleSortingAlgorithmTests: 6 тестов ✓
- HeapBasedAlgorithmTests: 5 тестов ✓
- QuickSelectAlgorithmTests: 5 тестов ✓
- PartialSortAlgorithmTests: 5 тестов ✓

## Git Workflow

1. Каждое задание выполняется в отдельной ветке
2. Основная ветка (main/master) всегда содержит рабочий код
3. По завершении создается Pull Request
4. Все файлы проекта хранятся в Git
5. Папки `bin`, `obj` исключены с помощью `.gitignore`

## Автор

Авторская работа для выполнения задания по .NET разработке

## Лицензия

MIT