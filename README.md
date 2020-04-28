# DecoratorSampleApp


Appli d'exemple du pattern décorateur, avec décorateurs génériques ouverts (_open generics_).

## Le pattern

Ce pattern nous permet d’ajouter des fonctionnalités nouvelles à une classe de façon dynamique sans impacter les classes qui l’utilisent ou en héritent.

## L'exemple
On définit une interface pour un repository générique `IGenericRepository<T>` avec une méthode `T GetById(int id)`.

`GenericRepository<T>` va implémenter l'interface et en fournir une implémentation.

`MovieRepository` et `UserRepository` héritent de `GenericRepository<Movie>`.

En appelant une méthode de l'un ou l'autre de ces _repositories_, on va appeler les décorateurs.

_Autofac_ va nous permettre de définir des décorateurs génériques, sans avoir besoin de préciser le type T.


## Décorateurs définis dans cet exemple

### GenericRepositoryLogDecorator
Ce décorateur générique ajoute simplement une fonctionnalité de log, sans toucher au repository décoré.

### GenericRepositoryCacheDecorator
Ce décorateur générique ajoute une fonctionnalité de cache glissant, sans toucher au repository décoré.

## Config Autofac

```c#
builder.RegisterGenericDecorator(
	typeof(GenericRepositoryLogDecorator<>),
	typeof(IGenericRepository<>)
);
```

## Technos utilisées
* Aspnetcore 3.1
* Autofac pour l'injection de dépendances 
* Serilog pour le log