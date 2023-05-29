all: preprocessing

preprocessing: preprocessing.o
	g++ preprocessing.o -o preprocessing

preprocessing.o: preprocessing.cpp
	g++ -c preprocessing.cpp

clean:
	rm -rf *.o preprocessing