   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	   5clr-namespace:WpfApp.PropertiesWpfApp.Properties  5   	       WpfApp.TeamStatsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   6
propertiesclr-namespace:WpfApp.Properties     5   	     ? WindowStartupLocation$  CenterScreen=?5	   	    ? Title$ TeamStatsWindow??5
   	   $	??450??6!   $	??400??6.    ? Triggers 5      :? 5   
    :? RoutedEvent$ Loaded??6   .[?5      ?? .??5      ??  g? Duration$ 
00:00:00:5D?6    ?? TargetProperty$ Width?63   .??5      W?  W? From$ 0X?6&   	 W? To$	 400X?6/   5      5      5      .??5      ?  ? RowDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      	 ? ColumnDefinitions	 5"   
   ?? 5#      6!   ?? 5$      6!   .+?5'   
   ?? -   5        $??lblHeadline??5'      $??0??6#   $??2??63   $??Center=?6h   $??Center=?6?   $??20(?6?   $??	ExtraBold"?6?   ??6G   ?? 
 ?? Path$
 Country?6?   ?? 5(   
   -   5        $??lblCode??5(      $??0??6    $??2??60   $??1??6D   $??Center=?6s   $??20(?6?   $
??Bold"?6?   ??6Q   ?? $
 FifaCode?6?   ?? 5)   
   $??2??6   !   WpfApp.Properties.Resources   lblGamesPlayed#??Z 6   $??Right=?6W   $??12(?6s   $??DemiBold"?6?   $??Center=?6?   ?? 5*   
   -   5        $??lblMatchesPlayed??5*       $??1??6   $??2??68   $
??Left=?6k   $??12(?6?   $??DemiBold"?6?   $??Center=?6?   $??5q?6?   ??6E   ?? $
 GamesPlayed?6?   ?? 5+   
   $??3??6      lblWins#??Z 6   $??Right=?6P   $??12(?6l   $??DemiBold"?6z   $??Center=?6?   ?? 5,   
   -   5        $??lblMatchesWon??5,       $??1??6   $??3??65   $
??Left=?6a   $??12(?6|   $??DemiBold"?6?   $??Center=?6?   $??5q?6?   ??6B   ?? $

 Wins?6?   ?? 5-   
   $??4??6      lblDraws#??Z 6   $??Right=?6Q   $??12(?6m   $??DemiBold"?6{   $??Center=?6?   ?? 5.   
   -   5        $??lblMatchesDrawn??5.       $??1??6   $??4??67   $
??Left=?6d   $??12(?6   $??DemiBold"?6?   $??Center=?6?   $??5q?6?   ??6D   ?? $
 Draws?6?   ?? 5/   
   $??5??6      	lblLosses#??Z 6   $??Right=?6R   $??12(?6n   $??DemiBold"?6|   $??Center=?6?   ?? 50   
   -   5        $??lblMatchesLost??50       $??1??6   $??5??66   $
??Left=?6d   $??12(?6   $??DemiBold"?6?   $??Center=?6?   $??5q?6?   ??6C   ?? $
 Losses?6?   ?? 51   
   $??6??6      	lblScored#??Z 6   $??Right=?6R   $??12(?6n   $??DemiBold"?6|   $??Center=?6?   ?? 52   
   -   5        $??lblGoalsScored??52       $??1??6   $??6??66   $
??Left=?6f   $??12(?6?   $??DemiBold"?6?   $??Center=?6?   $??5q?6?   ??6C   ?? $
 GoalsFor?6?   ?? 53   
   $??7??6      lblTaken#??Z 6   $??Right=?6Q   $??12(?6m   $??DemiBold"?6{   $??Center=?6?   ?? 54   
   -   5        $??lblGoalsTaken??54       $??1??6   $??7??65   $
??Left=?6i   $??12(?6?   $??DemiBold"?6?   $??Center=?6?   $??5q?6?   ??6B   ?? $
 GoalsAgainst?6?   ?? 55   
   $??8??6      
lblGoalDif#??Z 6   $??Right=?6S   $??12(?6o   $??DemiBold"?6}   $??Center=?6?   ?? 56   
   -	   5        $??
lblGoalDif??56      $??1??6"   $??8??62   $
??Left=?6j   $??12(?6?   $??DemiBold"?6?   $??Center=?6?   $??5q?6?   ??6?   ?? $
 GoalDifferential?6?   58      59      