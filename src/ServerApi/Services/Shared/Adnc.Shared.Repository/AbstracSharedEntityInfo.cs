﻿namespace Adnc.Shared.Entities;

public abstract class AbstracSharedEntityInfo : IEntityInfo
{
    public abstract IEnumerable<EntityTypeInfo> GetEntitiesTypeInfo();

    public abstract IEnumerable<Assembly> GetConfigAssemblys();

    protected virtual IEnumerable<Type> GetEntityTypes(Assembly assembly)
    {
        var typeList = assembly.GetTypes().Where(m =>
                                                   m.FullName != null
                                                   && typeof(EfEntity).IsAssignableFrom(m)
                                                   && !m.IsAbstract);
        if (typeList is null)
            typeList = new List<Type>();

        return typeList.Append(typeof(EventTracker));
    }

    protected virtual IEnumerable<Assembly> GetConfigAssemblys(Assembly assembly)
    {
        return new List<Assembly> { assembly, typeof(EventTracker).Assembly };
    }
}