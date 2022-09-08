// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using MediatR;

namespace BenjaminAbt.MyDemoPlatform.Engine.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
