## CheckIpAndPort
That method checks, if a given IP and a given port is accesable.

### Usage

```csharp
bool isAvailable = Firewall.CheckIpAndPort("127.0.0.1", 80);
```

The result value is a Ardalis.Result, what represents if its available or not.

## PingIp

Checks if a given IP is pingable.

### Usage

```csharp
bool isAvailable = Firewall.PingIp("127.0.0.1");
```

The result value is a Ardalis.Result, what represents if its available or not.