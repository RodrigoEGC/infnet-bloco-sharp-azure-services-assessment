### Desenvolvimento com serviços WCF e Microsoft Azure
### [AT publicado no Azure]()

* https://allmusix.azurewebsites.net/


```bash
ASSESSMENT [OBRIGATÓRIO]

Nesse Assessment, você deverá criar uma aplicação web (MVC) usando todos esses principais serviços que você 
aprendeu nessa disciplina.

Você deve criar um projeto do tipo ASP.NET Core Web Mvc com um CRUD básico 
(listagem, detalhe, inclusão, alteração, exclusão) 
cuja entidade tenha pelo menos cinco atributos diferentes, dos quais pelo menos três dos atributos 
devem possuir tipos diferentes.

As operações do CRUD devem persistir os dados da entidade em um banco de dados SQL do Azure.

Na operação de inclusão, a aplicação deve ser capaz de enviar uma 
mensagem para uma fila (dentro da mensagem deve conter o endereço web da imagem).
Esta fila deve ser consumida por uma function, o qual deve ser capaz de armazenar a imagem como Blob no Azure.

Esta função deve redimensionar a imagem em tamanho menor (miniatura) antes de armazená-la em um Blob. 
A página de detalhe deve ser capaz de exibir a imagem.

Caso seja informada uma nova imagem na operação de alteração, 
a aplicação deve ser capaz de primeiramente enviar uma mensagem para uma outra fila (exclusão), 
que deve ser consumida por uma function para exclusão do blob (imagem antiga). 

Logo em seguida, a aplicação deve ser capaz de enviar uma mensagem (contendo a o endereço da imagem nova) 
para a mesma fila utilizada na operação de inclusão.

Na operação de exclusão, a aplicação deve ser capaz de enviar uma mensagem para a mesma fila (a de exclusão) 
utilizada na operação de alteração.

As operações de inclusão, alteração e exclusão da entidade devem ser registradas 
como histórico (log) em uma tabela sem schema (NoSQL). 

Uma página deve ser desenvolvida para exibir o histórico (log) por tipo de operação (inclusão, alteração e exclusão).
Ao entrar nesta página, devem ser exibidos os históricos de exclusão.


```
