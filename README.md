### Запуск программы:

```Console
go run ./src/... <file> <clone file>
```

### Запуск автотестов:
```Console
go test ./src/...
```
Тесты на общую работу и на расстояние Левенштейна


### Препроцессинг:

запуск из директории `src/preprocessing/`
```Console
make
```

После сборки, для запуска:
```Console
./preprocessing input.txt output.txt
```

В таком случае 
`input.txt` - файл с содержанием изначального кода,
`output.txt` - с обработанным кодом
