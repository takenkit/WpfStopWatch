   M S B A M L   `   `   `  ����G  CWpfStopWatch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfStopWatchWpfStopWatch  5   	       WpfStopWatch.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )vmclr-namespace:WpfStopWatch     5   	     � Title$  	StopWatch��5   	   $	��450��6   $	��400��6(    � DataContext 5	      &    WpfStopWatch.MainWindowViewModel  5
   
    � 	Resources 5         vm    WpfStopWatch.TimeConverter  TimeConverter��%:   &	        &	        5   
   6!     5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��33* �6   �� 5      $	��71* �6   .+�5   
   �� -   5         ��Name$ 
txtDisplay��5      $
��Left=�6&   $��67��6A   $��	45,40,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6�   $	��300��6�   $
��Bold"�6�    �� TextAlignment$ Center=�6�   $��36(�6  ��6t   �� *	Elapsed+ �� Mode$ OneWay=� �� 	Converter# [ 6  �� 5   
   -   5        	 ��Name$	 btnStart��5      $��1��6#   $��START��60   $
��Left=�6@   $��	45,39,0,0q�6[   $	��Top=�6n   $��80��6�   $��40��6�   ��6�   �� *StartCommand+�� 5   
   -   5        $	 btnStop��5      $��1��6"   $
��STOP��6/   $
��Left=�6>   $��
153,39,0,0q�6Y   $	��Top=�6m   $��80��6�   $��40��6�   ��6�   �� *StopCommand+�� 5   
   -   5        $	 btnClear��5      $��1��6#   $
��Left=�6Q   $��
265,39,0,0q�6l   $	��Top=�6�   $��80��6�   $��40��6�   ��60   �� *ClearOrCheck+��6�   �� *ClearOrCheckCommand+�� 5   
   -   5        
 ��Name$
 
lbLapTimes��5      $
��Left=�6&   $	��144��6A   $��	45,10,0,0q�6N   $��2��6a   $	��Top=�6n   $	��300��6�   $��20(�6�   $
��Bold"�6�   ��6�   Z� ��6�   �� *
LapTimes+6�   5      5      