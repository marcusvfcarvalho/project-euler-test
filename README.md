Project Euler Test
==================
O objetivo desse projeto é resolver o problema proposto na página https://projecteuler.net/problem=11
que pede que se encontre o maior produto de quatro elementos adjacentes de uma matriz 20 x 20.

#Algumas considerações:
1 O problema não informa o que fazer no caso de elementos perto dos limites da matriz, onde não há elementos suficientes para o cálculo. Há duas possibilidades: ignorar esses elementos, ou percorrer o caminho completando os com elementos lado opostos da matriz. O programa contempla os dois cenários, apesar do primeiro ser o comportamento default. Um flag permite calcular completando a matriz. Entretanto, na matriz dada parece não fazer diferença.

2 O cálculo para cima, para esquerda, e as diagonais para cima são reduntantes, já que o cálculo para esquerda de um elemento qualquer é igual ao cálculo para a direira do elemento 4 posições à esquerda do elemento inicial. 

3 O sistema foi desenvolvido em C# no Visual Studio 2013 Community Edition.

