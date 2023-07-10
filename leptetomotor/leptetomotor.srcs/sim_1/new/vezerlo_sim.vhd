----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 11/04/2021 10:16:42 PM
-- Design Name: 
-- Module Name: vezerlo_sim - Behavioral
-- Project Name: 
-- Target Devices: 
-- Tool Versions: 
-- Description: 
-- 
-- Dependencies: 
-- 
-- Revision:
-- Revision 0.01 - File Created
-- Additional Comments:
-- 
----------------------------------------------------------------------------------


library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx leaf cells in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity vezerlo_sim is
--  Port ( );
end vezerlo_sim;

architecture Behavioral of vezerlo_sim is
component vezerlo is
    Port ( clk : in STD_LOGIC;
           reset : in STD_LOGIC;
           start : in STD_LOGIC;
           T1 : in STD_LOGIC_VECTOR (31 downto 0);
           N1 : in STD_LOGIC_VECTOR (31 downto 0);
           d1 : in STD_LOGIC_VECTOR (31 downto 0);
           T2 : in STD_LOGIC_VECTOR (31 downto 0);
           N2 : in STD_LOGIC_VECTOR (31 downto 0);
           d2 : in STD_LOGIC_VECTOR (31 downto 0);
           T3 : in STD_LOGIC_VECTOR (31 downto 0);
           N3 : in STD_LOGIC_VECTOR (31 downto 0);
           d3 : in STD_LOGIC_VECTOR (31 downto 0);
           EN : in STD_LOGIC;
           DIR : in STD_LOGIC;
           EN_OUT : out STD_LOGIC;
           DIR_OUT : out STD_LOGIC;
           IMP : out STD_LOGIC);
end component;

signal clk_sim :  STD_LOGIC;
signal reset_sim :  STD_LOGIC;
signal start_sim :  STD_LOGIC;
signal T1_sim :  STD_LOGIC_VECTOR (31 downto 0);
signal N1_sim :  STD_LOGIC_VECTOR (31 downto 0);
signal d1_sim :  STD_LOGIC_VECTOR (31 downto 0);
signal T2_sim :  STD_LOGIC_VECTOR (31 downto 0);
signal N2_sim :  STD_LOGIC_VECTOR (31 downto 0);
signal d2_sim :  STD_LOGIC_VECTOR (31 downto 0);
signal T3_sim :  STD_LOGIC_VECTOR (31 downto 0);
signal N3_sim :  STD_LOGIC_VECTOR (31 downto 0);
signal d3_sim :  STD_LOGIC_VECTOR (31 downto 0);
signal EN_sim :  STD_LOGIC;
signal DIR_sim :  STD_LOGIC;
signal EN_OUT_sim :  STD_LOGIC;
signal DIR_OUT_sim :  STD_LOGIC;
signal IMP_sim :  STD_LOGIC);

begin

constant clk_period : time := 10ns;

vezerlo : vezerlo PORT MAP(
    clk  => clk_sim,
    reset  => res_sim,
    start  => start_sim,
    T1  => T1_sim,
    N1  => N1_sim,
    d1  => d1_sim,
    T2  => T2_sim,
    N2  => N2_sim,
    d2  => d2_sim,
    T3  => T3_sim,
    N3  => N3_sim,
    d3  => d3_sim,
    EN  => EN_sim,
    DIR  => DIR_sim,
    EN_OUT  => EN_OUT_sim,
    DIR_OUT  => DIR_OUT_sim,
    IMP  => IMP_sim
);

clk_gen:process
begin
    clk_sim <= '0';
    wait for clk_period/2;
    clk_sim <= '1';
    wait for clk_period/2;
end process;

simulation: process
begin

    res_sim <= '1';
    start_sim <= '0';
    wait for 100 ns;
    res_sim <= '0';
    start_sim <= '1';
    kapcsolo_1_sim <= '1';
    kapcsolo_2_sim <= '0';
    gomb_le_sim <= '0';
    gomb_fel_sim <= '0';
    
    wait for 10ns;
    gomb_le_sim <= '1';
    wait for 51ms;
    gomb_le_sim <= '0';
    wait for 51ms;
    gomb_le_sim <= '1';
    wait for 51ms;
    gomb_le_sim <= '0';
    
    wait for 1000ms;

end process;


end Behavioral;
