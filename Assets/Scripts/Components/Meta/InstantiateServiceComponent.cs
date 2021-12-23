using Entitas;
using Entitas.CodeGeneration.Attributes;

[Meta, Unique]
public class InstantiateServiceComponent : IComponent
{
    public IInstantiateService InstantiateService;
}
