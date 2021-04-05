﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using ModernWpf;

namespace GenshinLyreMidiPlayer.ModernWPF
{
    public class AppThemes : List<AppTheme>
    {
        public AppThemes()
        {
            Add(AppTheme.Light);
            Add(AppTheme.Dark);
            Add(AppTheme.Default);
        }
    }

    public class AppTheme
    {
        private AppTheme(string name, ApplicationTheme? value)
        {
            Name  = name;
            Value = value;
        }

        public ApplicationTheme? Value { get; }

        public static AppTheme Light { get; } = new AppTheme("Light", ApplicationTheme.Light);

        public static AppTheme Dark { get; } = new AppTheme("Dark", ApplicationTheme.Dark);

        public static AppTheme Default { get; } = new AppTheme("Use system setting", null);

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class AppThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case ApplicationTheme.Light:
                    return AppTheme.Light;
                case ApplicationTheme.Dark:
                    return AppTheme.Dark;
                default:
                    return AppTheme.Default;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is AppTheme appTheme) return appTheme.Value;

            return AppTheme.Default;
        }
    }
}