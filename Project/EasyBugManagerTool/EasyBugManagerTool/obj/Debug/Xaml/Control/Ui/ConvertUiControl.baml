   M S B A M L   `   `   `  ����M  IEasyBugManagerTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EasyBugManagerToolEasyBugManagerTool  5      )    #EasyBugManagerTool.ConvertUiControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EasyBugManagerTool     5      -   5        $��ConvertUiUserControl��5      .��5      � .+�5   
   �� -   5        $��BackgroundBorder��5      $	��580��5      $	��420��6!   $��Center=�5      
�������  �� CornerRadius$  15��5   (    J� Opacity$ 1Q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$ 0Q�6#      ShadowDepth$ 0Q�61      
BlurRadius$ 20Q�6A      Opacity$
 0.25Q�5   '      Color$ 	#FF5B5B5B��66   6J   5      � 5   
   $	��580��6   $	��420��6   $��Center=�5      .+�5"      �� $��39.5,20,0,0q�6   $	��Top=�5#       $
��Left=�68      ZcoolButter.FontFamily#��[  5%       $��31(�5&       ���#787878��5$       ��  �� ElementName$ ConvertUiUserControl��	 �� Path$	 TitleString�5&   .   �� 5*      
 �� Orientation$
 
Horizontal=�6   $��	60,85,0,0q�62   $
��Left=�5+   !   $	��Top=�6<   .+�5.      �� $��Center=�6   $
��Left=�67   #��[  50   $   $��22(�51   $   ���#c0c0c0��5/   $   �� $ ConvertUiUserControl��$	 LocationString�51   2   +   %EasyBugManagerTool.ImageButtonControl  54      +   %EasyBugManagerTool.ImageButtonControl   Click$ BrowseButtonControl_Click��5;   3   $��46��54   +   $��40��66   $��35,0,0,0q�55   3   $	��Top=�56   3      PressAnimationSize$ 	0.85,0.85&�57   3    . *OtherUi.BrowseButton.MouseEnter.ImageBrush   MouseEnterImage# �  58   3    . *OtherUi.BrowseButton.MouseLeave.ImageBrush   MouseLeaveImage# �  59   3   5;   3   �� 5>      $	��300��5?   "   $��42��61   $��	10,4,15,0q�5@   "   $��0,0,10,0q�66   $y�Visible=�5A   "   $��0q�5C   "    �� SelectionBrush
 �����$��Center=�5E   "     ZcoolLiterary.FontFamily#��[ 5F   "   $��16(�5G   "   
������ ���	#FFA8A8A8 �� TextWrapping$
 Wrap=�5I   "    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�5K   "   ��5>      �� $ ConvertUiUserControl��$	 
PathString�5K   "   5N      �� 5R      -   5        $��TipTextBlock��5R      $��	40,60,0,0q�5S      $
��Left=�5T      $	��Top=�67   $	 0.8Q�5V      #��[ 5W      $��18(�5X       �� Padding$ 5,4,5,0q�6*   ���#852a2a��5U      �� $ ConvertUiUserControl��$	 	TipString�5X   <   �� 5]      $	��445��6   $	��171��6!   $��
80,200,0,0q�6.   $
��Left=�5^      $	��Top=�64    ! ConvertUi.Text.Tip.ImageBrush#���  5_       J� IsHitTestVisible .  5`      �� 5d      $
 
Horizontal=�6   $��
60,150,0,0q�5e      $
��Left=�5f      $	��Top=�68   .+�5i      �� $��0,6,0,0q�6   $��Center=�5j   !   $
��Left=�6<   #��[  5l   $   $��22(�5m   $   ���#c0c0c0��5k   $   �� $ ConvertUiUserControl��$	 CollaborationModeString�5m   2   *   $EasyBugManagerTool.ImageCheckControl  5q      -   5          Name$% IsCollaborationModeCheckControl��5q   *   $��33��5r   .   $��35��69   $��22,0,0,0q�6E   $
��Left=�5s   .   $��Center=�6I    $  OtherUi.Check.Uncheck.ImageBrush   MouseLeaveImage# �  5t   .      MouseEnterImage# �  5u   .    $  OtherUi.Check.Checked.ImageBrush   CheckedImage# �  5v   .      	IsChecked 5w   .   �� $ ConvertUiUserControl��$	 IsCollaborationMode� �� Mode$ TwoWay=�5x      5}      �� 5�   
   $��83��6   $��572,-270,0,0q�6    $��Center=�5�      $��Center=�66   .+�5�      )   #EasyBugManagerTool.YesButtonControl  )   #EasyBugManagerTool.YesButtonControl   Click$ YesButtonControl_Click��5�   )   $��73��5�   %   $��62��60   $��0,0,0,0q�6<      PressAnimationSize$ 	0.85,0.85&�5�   )    * &MainUi.YesButton.MouseLeave.ImageBrush   MouseLeaveImage# �  5�   )    * &MainUi.YesButton.MouseEnter.ImageBrush   MouseEnterImage# �  5�   )   $��Right=�5�   )   5�   )   (   "EasyBugManagerTool.NoButtonControl  5�      (   "EasyBugManagerTool.NoButtonControl   Click$ NoButtonControl_Click��5�   (   $��70��5�   $   $��57��6/   $��2,3,0,0q�6;       PressAnimationSize$  	0.85,0.85&�5�   (    )	 %MainUi.NoButton.MouseLeave.ImageBrush!   MouseLeaveImage#! � 	 5�   (    )
 %MainUi.NoButton.MouseEnter.ImageBrush"   MouseEnterImage#" � 
 5�   (   5�   (   5�      � 5�   
   -   5        $��ForegroundCanvas��5�      $
 0.75Q�5�      $y�	Collapsed=�5�      .+�5�      �� $	��580��6   $	��420��6!   $��Center=�5�      
���   �$  14��5�   (   $ 1Q�5�      �� 5�      $��83��6   $��573,-270,0,0q�6$   $��Center=�5�      $��Center=�66   .+�5�      �� $��73��6   $��62��6$   $��0,0,0,0q�60   $��Right=�5�       * &MainUi.Foreground.YesButton.ImageBrush#���  5�        5�      $��70��6(   $��57��63   $��1,3,0,0q�6?    ) %MainUi.Foreground.NoButton.ImageBrush#���  5�   (   5�      5�      5�      5�      