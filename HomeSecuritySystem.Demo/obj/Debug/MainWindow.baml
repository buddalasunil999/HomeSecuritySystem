   M S B A M L   `   `   `  ����Q  MHomeSecuritySystemDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:HomeSecuritySystemDemoHomeSecuritySystemDemo  5   	   '    !HomeSecuritySystemDemo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:HomeSecuritySystemDemo     5   	   systemclr     5   	     � Title$  Home Security System��5	   	   $��522.369��6&   $��859.211��67   .��5
      � .+�5   
   �� ���	#FFF4F4F5$
��Left=�6%   $	��102��6@   $��	53,39,0,0q�6M   
���   �$	��Top=�6o   $��93��6�   �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $	��102��6@   $��
168,39,0,0q�6M   
���   �$	��Top=�6p   $��93��6�   �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $��65��6@   $��
276,39,0,0q�6L   
���   �$	��Top=�6o   $��93��6�   �� 5   
   -   5         ��Name$ lblSmokeSensor��5      $��Smoke Sensor��6(   $
��Left=�6?   $��	57,48,0,0q�6Z   $	��Top=�6m    J� RenderTransformOrigin$ 
0.03,0.451&�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblMotionSensor��5      $��Motion Sensor��6)   $
��Left=�6A   $��
171,49,0,0q�6\   $	��Top=�6p   $ 
0.03,0.451&�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblPowerSupply��5      $��Power Supply��6(   $
��Left=�6?   $��
282,50,0,0q�6Z   $	��Top=�6n   $ 
0.03,0.451&�6�   $
��Bold"�6�   	� 5   
   -   5         	�Name$ rbSmokeSensorOn��5      $��On��6/    	� 	GroupName$ smoke��6<   $
��Left=�6N   $��	62,78,0,0q�6i   $	��Top=�6|   6�   	� 5   
   -   5        $ rbSmokeSensorOff��5      $	��Off��60   $ smoke��6>   $
��Left=�6P   $��
100,78,0,0q�6k   $	��Top=�6   6�   	� 5   
   -   5        $ rbMotionSensorOn��5      $��On��60   $ motion��6=   $
��Left=�6P   $��
175,79,0,0q�6k   $	��Top=�6   6�   	� 5   
   -   5        $ rbMotionSensorOff��5      $	��Off��61   $ motion��6?   $
��Left=�6R   $��
213,79,0,0q�6m   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ btnTriggerSmokeSensor��5      $��Trigger��60   $
��Left=�6B   $��	62,99,0,0q�6]   $	��Top=�6p   $��75��6�   $ 0.095,-0.605&�6�   $��31��6�   �� 5   
   -	   5        $ btnTriggerMotionSensor��5      $��Trigger��61   $
��Left=�6C   $��175,100,0,0q�6^   $	��Top=�6s   $��75��6�   $ 0.095,-0.605&�6�   $��30��6�   �� 5   
   -
   5         ��Name$ cbPowerSupplyOff��5      $��BlackOut��6-   $
��Left=�6@   $��
283,78,0,0q�6[   $	��Top=�6o   6�   �� 5   
   -   5        $ cbArm��5      $	��Arm��6"   $
��Left=�60   $��114,176,0,0q�6K   $	��Top=�6`   6x   �� 5   
   -   5        $ cbStay��5      $
��Stay��6#   $
��Left=�62   $��168,176,0,0q�6M   $	��Top=�6b   6z   �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $��59��6@   $��276,117,0,0q�6L   
���   �$	��Top=�6p   $��93��6�   �� 5   
   -   5        $ lblAlarm��5      $��Alarm��6"   $
��Left=�62   $��301,122,0,0q�6M   $	��Top=�6b   $ 
0.03,0.451&�6z   $
��Bold"�6�   	� 5   
   -   5        $ 	rbAlarmOn��5      $��On��6)   $ alarm��66   $
��Left=�6H   $��286,146,0,0q�6c   $	��Top=�6x   6�   	� 5   
   -   5        $ 
rbAlarmOff��5      $	��Off��6*   $ alarm��68   $
��Left=�6J   $��324,146,0,0q�6e   $	��Top=�6z   6�   �� 5   
   -   5         ��Name$ groupBox��5      $��Display��6%   $
��Left=�66   $��
400,39,0,0q�6Q   $	��Top=�6e   $	��432��6}   $	��426��6�   .��5       $   HomeSecuritySystemDemo.Display  -   5          Name$ userDisplay��5       $
��Left=�61   $��6,1,0,0q�6L   $	��Top=�6]   $	��355��6u   $	��400��6�   5!      �� 5"   
   -   5        $ btnClear��5"      $��Clear��6#   $
��Left=�63   $��
751,14,0,0q�6N   $	��Top=�6b   $��75��6z   $��25��6�   6�   5#      5$      