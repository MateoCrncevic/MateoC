   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.PropertiesWpfApp.Properties  5   	   clr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6
propertiesclr-namespace:WpfApp.Properties     5   	   &localclr-namespace:WpfApp     5   	     ? Title$  
MainWindow??5	   	   $	??700??6   $	??700??6)    ? WindowStartupLocation$ CenterScreen=?65   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??80 ?6   ?? 5      ?? 5       ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      ?? 5      ?? 5      ?? 5      $
??Auto ?6   .+?5   
   c? $??6??5      .@?5       ?? -   5         ??Name$ btnSettings??5!      !   WpfApp.Properties.Resources   btnSettings#??Z 5       $??Stretch=?5"   /   5#      ?? 5%   
   -   5         ??Name$ 
cbMainTeam??5(      $??1??5&      $??1??5'      $??20??5)      $	??150??5*      $??30q?5+      5-      ?? 5/   
   -   5        $ btnMainTeamDisplay??50      $??1??51      $??1??52         btnMainTeamDisplay#??Z 53      $??
30,55,30,0q?54      $	??Top=?55      $??90??56      58      ?? 5:   
   -   5        $ cbOtherTeam??5=      $??1??5;      $??5??5<      $??20??5>      $	??150??5?      $??30q?5@      5B      ?? 5D   
   -   5        $ btnOtherTeamDisplay??5E      $??1??5F      $??5??5G         btnShowStats#??Z 5H      $??
30,55,30,0q?5I      $	??Top=?5J      $??90??5K      5M      ?? 5O   
   -   5        $??lblMainTeamScore??5O      $??1??6(   $?? ??65   $??2??6@   $??Center=?6P   $??Right=?6k   $??25(?6?   ?? 5P   
   -   5        $??lblScoreDelimiter??5P      $??1??6)   $??3??67   $??:??6G   $??30(?6S   $??Center=?6a   $??Center=?6|   ?? 5Q   
   -   5        $??lblOtherTeamScore??5Q      $??1??6)   $?? ??66   $??4??6A   $??Center=?6R   $
??Left=?6m   $??25(?6?   ? 5S   
   -	   5        	 ?Name$	 startingElevenGrid??5T      $??2??5U      $??2??5V      $??6??5W      $??30q?5X      ??5Z      ?? 5[      
 ?? ImageSource$
 Images/unnamed.png??6    j? Stretch$
 Fill=?6>    5^      ?? 5_      ?? 5`      .+?5c      ? -
   5        $	 grdMainTeamStartingEleven??5c       5d      ?? 5e      ?? 5f      ?? 5g      ?? 5h      .+?5j      ?? -   5         ??Name$ pnlMainGoalee??5j   O    ?? Orientation$ Vertical=?6   $??Center=?64   6O   ?? 5k      -   5        $ pnlMainDefence??5k   O   $ Vertical=?6   $??Center=?64   $??1??6g   ?? 5l      -   5        $ pnlMainMidfield??5l   O   $ Vertical=?6   $??Center=?64   $??2??6i   ?? 5m      -   5        $ pnlMainOffence??5m   O   $ Vertical=?6   $??Center=?64   $??3??6h   5o      ? 5p      -   5        $ 	 grdOtherTeamStartingEleven??5p      $??1??67    5q      ?? 5r      ?? 5s      ?? 5t      ?? 5u      .+?5w      ?? -   5        $ pnlOtherOffence??5w   O   $ Vertical=?6   $??Center=?64   6O   ?? 5x      -   5        $ pnlOtherMidfield??5x   P   $ Vertical=?6   $??Center=?64   $??1??6j   ?? 5y      -   5        $ pnlOtherDecence??5y   P   $ Vertical=?6   $??Center=?64   $??2??6i   ?? 5z      -   5        $ pnlOtherGoalee??5z   P   $ Vertical=?6   $??Center=?64   $??3??6h   5{      5}      5~      5      