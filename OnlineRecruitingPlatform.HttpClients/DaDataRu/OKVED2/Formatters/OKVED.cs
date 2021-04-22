namespace OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Formatters
{
    public class OKVED
    {
        private readonly int? _class;
        private readonly int? _subclass;
        private readonly int? _group;
        private readonly int? _subgroup;
        private readonly int? _kind;

        public OKVED(int classPartial)
        {
            _class = classPartial >= 0 && classPartial <= 99 ? classPartial : 0;
        }

        public OKVED(int classPartial, int subclassPartial)
        {
            _class = classPartial >= 0 && classPartial <= 99 ? classPartial : 0;
            _subclass = subclassPartial >= 0 && subclassPartial <= 9 ? subclassPartial : 0;
        }

        public OKVED(int classPartial, int subclassPartial, int groupPartial)
        {
            _class = classPartial >= 0 && classPartial <= 99 ? classPartial : 0;
            _subclass = subclassPartial >= 0 && subclassPartial <= 9 ? subclassPartial : 0;
            _group = groupPartial >= 0 && groupPartial <= 9 ? groupPartial : 0;
        }

        public OKVED(int classPartial, int subclassPartial, int groupPartial, int subgroupPartial)
        {
            _class = classPartial >= 0 && classPartial <= 99 ? classPartial : 0;
            _subclass = subclassPartial >= 0 && subclassPartial <= 9 ? subclassPartial : 0;
            _group = groupPartial >= 0 && groupPartial <= 9 ? groupPartial : 0;
            _subgroup = subgroupPartial >= 0 && subgroupPartial <= 9 ? subgroupPartial : 0;
        }

        public OKVED(int classPartial, int subclassPartial, int groupPartial, int subgroupPartial, int kindPartial)
        {
            _class = classPartial >= 0 && classPartial <= 99 ? classPartial : 0;
            _subclass = subclassPartial >= 0 && subclassPartial <= 9 ? subclassPartial : 0;
            _group = groupPartial >= 0 && groupPartial <= 9 ? groupPartial : 0;
            _subgroup = subgroupPartial >= 0 && subgroupPartial <= 9 ? subgroupPartial : 0;
            _kind = kindPartial >= 0 && kindPartial <= 9 ? kindPartial : 0;
        }

        public bool IsFormatWithClass()
        {
            return _class != null && _subclass == null && _group == null && _subgroup == null && _kind == null;
        }

        public bool IsFormatWithSubClass()
        {
            return _class != null && _subclass != null && _group == null && _subgroup == null && _kind == null;
        }

        public bool IsFormatWithGroup()
        {
            return _class != null && _subclass != null && _group != null && _subgroup == null && _kind == null;
        }

        public bool IsFormatWithSubGroup()
        {
            return _class != null && _subclass != null && _group != null && _subgroup != null && _kind == null;
        }

        public bool IsFormatWithKind()
        {
            return _class != null && _subclass != null && _group != null && _subgroup != null && _kind != null;
        }

        public string GetFormat()
        {
            if (_kind == null)
            {
                if (_subgroup == null)
                {
                    if (_group == null)
                    {
                        if (_subclass == null)
                        {
                            return $"{(_class < 10 ? $"0{_class}" : $"{_class}")}";
                        }

                        return $"{(_class < 10 ? $"0{_class}" : $"{_class}")}.{_subclass}";
                    }

                    return $"{(_class < 10 ? $"0{_class}" : $"{_class}")}.{_subclass}{_group}";
                }

                return $"{(_class < 10 ? $"0{_class}" : $"{_class}")}.{_subclass}{_group}.{_subgroup}";
            }

            return $"{(_class < 10 ? $"0{_class}" : $"{_class}")}.{_subclass}{_group}.{_subgroup}{_kind}";
        }
    }
}
