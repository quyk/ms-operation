# ms-operation

Microserviço de teste que realiza transferência de valores entre contas.


#### Dependências 

| Nugets | Version |
| ------ | ------ |
| .NETCore2.2 | 2.2 |
| .NETStandard2.2 | 2.2 |
| Microsoft.Extensions.DependencyInjection | 2.2.0 |
| Microsoft.AspNetCore.Mvc.Abstractions | 2.2.0 |
| Microsoft.AspNetCore.Mvc.Core | 2.2.0 |
| Microsoft.NET.Test.Sdk | 16.0.1 |
| Moq | 4.10.1 |
| Newtonsoft.Json | 12.0.1 |
| Newtonsoft.Json.Schema | 3.0.10 |
| xunit | 2.4.1 |
| xunit.runner.visualstudio | 2.4.1 |

### Endpoints

> Transferência

**POST** | */api/transfer*

**Payload**
```json
{
    "origin": {
        "number": 3322
    },
    "destination": {
        "number": 553
    },
    "value": 1500.50
}
```

> Todas as contas

**GET** | */api/account*


> Conta pelo número

**GET** | */api/account/{number}*


### Contas pré cadastradas

```csharp
new List<Account>
{
    new Account
    {
        Number = 3064,
        Balance = 100.00,
        Limit = true
    },
    new Account()
    {
        Number = 0810,
        Balance = 50.00,
        Limit = false
    },
    new Account
    {
        Number = 3025,
        Balance = 500.00,
        Limit = false
    },
    new Account
    {
        Number = 0553,
        Balance = 0.00,
        Limit = false
    },
    new Account
    {
        Number = 3322,
        Balance = -10.00,
        Limit = true
    },
    new Account
    {
        Number = 6828,
        Balance = 125.00,
        Limit = false
    }
};
```

## License

Copyright (c) Quyk Mendonça. All rights reserved.

Licensed under the [MIT](LICENSE) License.
