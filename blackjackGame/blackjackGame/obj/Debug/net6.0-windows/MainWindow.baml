   M S B A M L   `   `   `  ����H  DblackjackGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:blackjackGameblackjackGame  5   	       blackjackGame.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:blackjackGame     5   	     � Title$  	Blackjack��5   	   $	��400��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      � .+�5
   
   �� -   5         ��Name$ playerCardsListBox��5
      $��10,44,640,192q�6.   �� 5   
   -   5        $ dealerCardsListBox��5      $��640,49,10,192q�6.   �� 5   
   -   5         ��Name$ staticPlayerLabel��5      $��Player��6+   $��Center=�6<   $
��Left=�6`   $��	10,18,0,0q�6{   $	��Top=�6�   $	��150��6�   $
��Bold"�6�   �� 5   
   -   5        $ staticDealerLabel��5      $��Dealer��6+   $��Center=�6<   $
��Left=�6`   $��
640,18,0,0q�6{   $	��Top=�6�   $	��150��6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ gameResultTextBlock��5      $��Center=�61   $��0,44,0,0q�6N   $
��Wrap=�6`   $�� ��6t   $	��Top=�6|   $
��Bold"�6�   $��24(�6�   �� 5   
   -   5        $ staticPlayerScoreLabel��5      $��Score :��60   $
��Left=�6B   $��
10,189,0,0q�6]   $	��Top=�6q   $
��Bold"�6�   �� 5   
   -   5        $ staticDealerScoreLabel��5      $��Score :��60   $
��Left=�6B   $��640,189,0,0q�6]   $	��Top=�6r   $
��Bold"�6�   �� 5   
   -   5        $ playerScoreLabel��5      $��0��6*   $
��Left=�66   $��
60,189,0,0q�6Q   $	��Top=�6e   �� 5   
   -	   5        $ dealerScorelabel��5      $��0��6*   $
��Left=�66   $��690,189,0,0q�6Q   $	��Top=�6f   �� 5   
   -
   5         ��Name$ startButton��5      $
��Play��6&   $��76��65   $��Center=�6@   $	��Top=�6]   $��	0,147,0,0q�6�   �� 5   
   -   5        $ 	hitButton��5      $	��Hit��6$   $��76��62   $��Center=�6=   $��	0,172,0,0q�6Z   $	��Top=�6m   6�   �� 5   
   -   5        $ standButton��5      $��Stand��6&   $��76��66   $��Center=�6A   $��	0,197,0,0q�6^   $	��Top=�6q   6�   �� 5   
   -   5        $ 
quitButton��5      $
��Quit��6%   $��76��64   $��Center=�6?   $��	0,246,0,0q�6\   $	��Top=�6o   6�   �� 5   
   -   5        $ staticBankrollLabel��5      $��
Bankroll :��6-   $
��Left=�6B   $��
10,224,0,0q�6]   $	��Top=�6q   �� 5   
   -   5         ��Name$ bankrollTextBox��5      $
��Left=�6+   $��110,228,0,0q�6F    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $��93��6�   ${�False��6�   �� 5   
   -   5        $ amountToBetStaticLabel��5      $��Amount to bet :��60   $
��Left=�6J   $��
10,290,0,0q�6e   $	��Top=�6y   �� 5   
   -   5        $ twentyButton��5      $	��$20��6'   $
��Left=�65   $��110,293,0,0q�6P   $	��Top=�6e   $��94��6}   6�   �� 5   
   -   5        $ fiftyButton��5      $	��$50��6&   $
��Left=�64   $��209,293,0,0q�6O   $	��Top=�6d   $��94��6|   6�   �� 5   
   -   5        $ hundredButton��5      $
��$100��6(   $
��Left=�67   $��308,293,0,0q�6R   $	��Top=�6g   $��94��6   6�   �� 5   
   -   5        $ twoHundredButton��5      $
��$200��6+   $
��Left=�6:   $��407,293,0,0q�6U   $	��Top=�6j   $��94��6�   6�   �� 5   
   -   5        $ customBetStaticLabel��5      $��Custom :��6.   $
��Left=�6A   $��
47,310,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ customBetAmountTextBox��5      $
��Left=�62   $��109,318,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $��93��6�   �� 5    
   -   5        $ placeCustomBetButton��5       $��	Place Bet��6/   $��94��6C   $
��Left=�6N   $��506,293,0,0q�6i   $	��Top=�6~   $
��Bold"�6�   �� 5!   
   -   5        $ poolAmountstaticLabel��5!      $��Money in the pool :��6/   $��Center=�6M   $��0,82,0,0q�6j   $	��Top=�6|   �� 5"   
   -   5        $ poolAmountTextBox��5"       �� TextAlignment$ Center=�6-   $��Center=�6D   $��	0,105,0,0q�6a   $
 Wrap=�6t   ${�False��6�   $	��Top=�6�   $	��113��6�   �� 5#   
   -   5        $ resetButton��5#      $��Reset��6&   $��Center=�66   $��	0,222,0,0q�6S   $	��Top=�6f   $��76��6~   6�   �� 5$   
   -   5        $ packsStaticLabel��5$      $��
Difficulty��6*   $
��Left=�6?   $��454,144,0,0q�6Z   $	��Top=�6o   $
��Bold"�6�   �� 5%   
   -   5        	 ��Name$	 difficultySlider��5%      
 � Minimum$
 1Q�6+    � Maximum$ 3Q�67    �� TickFrequency$ 1Q�6E    �� IsSnapToTickEnabled$
 True��6W    �� Orientation$ Vertical=�6r   $
��Left=�6�   $��463,178,0,0q�6�   $	��Top=�6�   $��19��6�   $��71��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5&      V� 5'      .~�5(      �� �� 5)      �� 5*       �� Angle$ 179.779Q�6&   T� 5+      5,      5.      �� 5/   
   -   5        $ easyStaticLabel��5/      $
��Easy��6)   $
��Left=�68   $��489,169,0,0q�6S   $	��Top=�6h   �� 50   
   -   5        $ difficultStaticLabel��50      $
��Hard��6.   $
��Left=�6=   $��489,228,0,0q�6X   $	��Top=�6m   �� 51   
   -   5        $ mediumStaticLabel��51      $��Medium��6+   $
��Left=�6<   $��489,200,0,0q�6W   $	��Top=�6l   53      54      