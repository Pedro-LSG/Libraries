# Libraries
#### Projeto destinado a criar bibliotecas em .net com c# para facilitar o desenvolvimento de projetos futuros.

- A biblioteca LOG tem como finalidade realizar a gravação de log localmente numa pasta específica que pode ser configurada, os logs serão gravados num zip dentro da pasta cujo nome será ordenado pela data corrente. [^1]
- Também estou desenvolvendo uma biblioteca de envio de email para que esse processo tão usual também possa ser facilitado. [^2]

----

#### Autor

Pedro Luis dos Santos Gomes. | [Linkedin](https://www.linkedin.com/in/pedrogomesdev/) | Contato: pedroluis20202@gmail.com

[^1]: Contruído inteiramente em c#, o método de gravação de log receberá um genérico, fará a serialização e gravará como string. Os atibutos que podem ser passados são o conteúdo a ser salvo, o nome do arquivo, uma mensagem padrão e a stack trace do erro, sendo o último opcional.
[^2]: Em desenvolvimento.
