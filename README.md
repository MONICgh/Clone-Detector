### Пример запуск программы:

```Console
go run src/main.go src/simple_update.go tests/taskCF.cpp tests/taskCF_clone.cpp
```

```Console
Detect dp : 85.46666666666667 %
Dublicate line : 80.64516129032258 %
Match Probability:  97.18709677419355 %
```

Запуск автотестов:
```Console
go test src/main.go src/simple_update.go src/main_test.go
```