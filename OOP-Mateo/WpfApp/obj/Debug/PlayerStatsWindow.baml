   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.PropertiesWpfApp.Properties  5   	   clr-namespace:WpfAppWpfApp  5   	   !    WpfApp.PlayerShowcaseWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6
propertiesclr-namespace:WpfApp.Properties     5   	   &localclr-namespace:WpfApp     5   	   -   5          ?Name$  w1??5   	    ? Title$ PlayerStatsWindow??5
   	   $	??400??6#   $	??600??60    ? WindowStartupLocation$ CenterScreen=?6<    ? Triggers 5      :? 5   
    :? RoutedEvent$ Window.Loaded??6   [?5      ?? 5      .??5      ??  g? 	BeginTime$ 0X?6!    g? Duration$ 3D?6/   .??5      W?  ?? 
TargetName$ w1??6*    ?? TargetProperty$ (Window.Top)?6E   	 W? From$	 0X?6n   	
 W? To$	
 300X?6w   $ 0:0:0X?6?   $ 0:0:1D?6?   W? 5      $ w1??6*   $ Height?6E   $	 0X?6h   $	
 400X?6q   $ 0:0:0X?6{   $ 0:0:1D?6?   5      5      5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      ?? 5      .+?5"   
   ?? -   5         ??Name$ imgPlayerImage??5"      $??0??6(   $??1??65   $??Images/blankPerson.png??6E   $
??Fill=?6e   $	??120??6t   $	??140??6?   $??Center=?6?   $	??Top=?6?   ?? 5#   
   -   5         ??Name$ lblShirtNumber??5#      $??0??6(   $??0??65   $??10??6E   $??	UltraBold"?6R   $??64(?6i   $??Center=?6w   $??Center=?6?   ?? 5$   
   -   5        $ lblPosition??5$      $??0??6%   $??0??62   $??Goalie??6B   $??Normal"?6S   $??45(?6g   $??Center=?6u   $??Bottom=?6?   ?? 5%   
   -   5        $ lblPlayerName??5%      $??0??6'   $??1??64   $??Mateo Crncevic??6D   $??Normal"?6]   $??30(?6q   $??Center=?6   $??Bottom=?6?   ?? 5&   
   -   5        $ lblCaptaincy??5&      $??1??6&   $??0??63   $	??CAP??6C   $
??Bold"?6Q   $??40(?6c   $??Center=?6q   $??Center=?6?   ?? 5'   
    ?? Orientation$ Vertical=?6   $??1??6,   $??1??69   .+?5(      ?? !   WpfApp.Properties.Resources   lblPlayerScored#??Z 6   $??Normal"?6N   $??20(?6b   $??Center=?6p   ?? 5)   
   -   5        $ lblGoals??5)      $??2??6"   $
??Bold"?6.   $??20(?6@   $??Center=?6N   ?? 5*         lblPlayerCards#??Z 6   $??Normal"?6M   $??20(?6a   $??Center=?6o   ?? 5+   
   -   5        $ lblCards??5+      $??0??6"   $
??Bold"?6.   $??20(?6@   $??Center=?6N   5,      5-      5.      