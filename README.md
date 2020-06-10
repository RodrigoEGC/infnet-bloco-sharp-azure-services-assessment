### Desenvolvimento com serviços WCF e Microsoft Azure
### [TP3 publicado no Azure]()

*https://allmusix.azurewebsites.net/


```bash
TESTE DE PERFORMANCE - TP3 [OBRIGATÓRIO]

Nas etapas 5 e 6 da disciplina de Desenvolvimento com Microsoft Azure, você compreendeu o que é o serviço de armazenamento em Fila do Azure, e como trabalhar com processos assíncronos e desacoplados. Você também aprendeu a usar o serviço de funções sem servidor (serverless) com custo baixíssimo para realizar pequenos procedimentos na nuvem da Microsoft.

Nesse TP03, você deve criar um projeto do tipo ASP.NET Core Web MVC. Nesse projeto você deve desenvolver um CRUD básico (listagem, detalhe, inclusão, alteração, exclusão) cuja entidade tenha pelo menos cinco atributos diferentes (incluindo o endereço web de uma imagem), dos quais pelo menos três dos atributos devem possuir tipos diferentes. As operações do CRUD devem persistir os dados da entidade em um banco de dados SQL do Azure.

Na operação de inclusão, a aplicação deve ser capaz de enviar uma mensagem para uma fila (dentro da mensagem deve conter o endereço web da imagem). Esta fila deve ser consumida por uma function, o qual deve ser capaz de armazenar uma imagem como Blob no Azure. A página de detalhe deve ser capaz de exibir a imagem.

Adicionalmente, a aplicação desenvolvida deve conter projetos e classes de acordo com os princípios do Domain Driven Design (DDD) estudados em aula. Antes de fazer sua entrega no moodle, versione sua aplicação em um repositório privado no GitHub no formato Azure-TPX-Meu_Nome (utilize o nome do curso, o teste correspondente e o seu próprio nome para identificar o repositório). Publique sua aplicação web no Azure e por último convide o seu professor como colaborador do repositório criado. O convite no GitHub deve ser feito até o prazo estabelecido no moodle. O envio do convite configura entrega final do trabalho, onde a partir de então o professor poderá efetuar um fork (cópia) para correção final.

Para fins administrativos (controle de nota), realize também entrega no moodle com um arquivo no formato que desejar contendo endereço do seu repositório GitHub, endereço da aplicação web executando no azure.
```
## [Screenshots]()
<img src="./TP3.png">
