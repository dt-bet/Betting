//using phirSOFT.LazyDictionary;
//using System;
//using System.Linq;

//namespace Betting.Abstract.DAL
//{


//    public class ObjectIdRepository
//    {
//        readonly LazyDictionary<Type, Type> lazyDict;
//        readonly LazyDictionary<Type, MyRef<long>> lazyDict3;
//        readonly LazyDictionary<object, long> lazyDict2;

//        public ObjectIdRepository()
//        {
//            lazyDict = new LazyDictionary<Type, Type>(t => UtilityHelper.TypeHelper.GetInheritingTypes(t).LastOrDefault() ?? t);
//            lazyDict3 = new LazyDictionary<Type, MyRef<long>>(t => new MyRef<long> { Ref = GetLastId(t) });
//            lazyDict2 = new LazyDictionary<object, long>(dbe => ++lazyDict3[lazyDict[dbe.GetType()]].Ref);
//        }


//        public long FindId(object obj)
//        {
//            return lazyDict2[obj];
//        }

//        protected virtual long GetLastId(Type type)
//        {
//            return 0;
//        }

//        class MyRef<T>
//        {
//            public T Ref { get; set; }
//        }

//    }
//}
