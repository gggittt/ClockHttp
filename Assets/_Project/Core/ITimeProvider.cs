using System;

namespace _Project.Core
{
interface ITimeProvider
{
    DateTime GetCurrentUtcDateTime( );
}
}