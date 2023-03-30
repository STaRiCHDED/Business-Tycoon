using System;
using System.Collections.Generic;
using Services;

public class ServiceLocator : IDisposable
{
    public static ServiceLocator Instance => _instance ??= new ServiceLocator();

    private readonly Dictionary<Type, IService> _services = new();
        
    private static ServiceLocator _instance;

    private ServiceLocator()
    {
    }
    
    public void RegisterSingle<TService>(TService service) where TService : IService
    {
        _services[typeof(TService)] = service;
    }

    public TService GetSingle<TService>() where TService : class, IService
    {
        return _services[typeof(TService)] as TService;
    }
    
    public void Dispose()
    {
        foreach (var service in _services.Values)
        {
            if (service is IDisposable disposableService)
            {
                disposableService.Dispose();
            }
        }
    }
}