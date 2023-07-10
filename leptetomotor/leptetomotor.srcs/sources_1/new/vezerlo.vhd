----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 11/04/2021 09:43:28 PM
-- Design Name: 
-- Module Name: vezerlo - Behavioral
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
use IEEE.NUMERIC_STD.ALL;
use IEEE.STD_LOGIC_UNSIGNED.ALL;
--use IEEE.STD_LOGIC_ARITH.ALL

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values


-- Uncomment the following library declaration if instantiating
-- any Xilinx leaf cells in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity vezerlo is
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
end vezerlo;

architecture Behavioral of vezerlo is

type allapotok is(RDY,INIT_A,DELAY_1,DEK_1,INIT_B,DELAY_2,KONST,INIT_C,DELAY_3,INK,Vege);
signal akt_all, kov_all : allapotok := RDY;

signal Ri :in STD_LOGIC_VECTOR (31 downto 0);
signal Rk :in STD_LOGIC_VECTOR (31 downto 0);
signal Rt :in STD_LOGIC_VECTOR (31 downto 0);
signal Ri_next :in STD_LOGIC_VECTOR (31 downto 0);
signal Rk_next :in STD_LOGIC_VECTOR (31 downto 0);
signal Rt_next: in STD_LOGIC_VECTOR (31 downto 0);

begin
AR:process(clk,reset)
begin
    if reset = '1' then
        akt_all<=RDY;
        --Ri<= (OTHERS => '0');
    elsif clk'event and clk = '1' then
        akt_all<=kov_all;
        --Ri<=Ri_next;
    end if;
end process;

KAL:process(akt_all,start,Ri)
begin
    case(akt_all) is
        when RDY =>
            if start='1' then
                kov_all<=INIT_A;
            else 
                kov_all<=RDY;
            end if;
        when INIT_A =>
            kov_all<=DELAY_1;
        when DELAY_1 =>
            if Ri > 0 then
                kov_all<=DELAY_1;
            else
                kov_all<=DEK_1;
            end if;
        when DEK_1 =>
            if Rk > 0then
                kov_all<=INIT_A;
            else
                kov_all<=INIT_B;
            end if;
        when INIT_B =>
            kov_all<=DELAY_2;
        when DELAY_2 =>
            if Ri > 0 then
                kov_all<=DELAY_2;
            else
                kov_all<=KONST;
            end if;
        when KONST =>
            if Rk > 0  then
                kov_all <= INIT_B;
            else 
                kov_all <= INIT_C;
            end if;
            
        when INIT_C =>
            kov_all <= DELAY_3;
        when DELAY_3 =>
            if Ri > 0 then
                kov_all <= DELAY_3;
            else 
                kov_all <= INK;
            end if;
        when INK =>
            if Rk > 0 then
                kov_all <= INIT_C;
            else
                kov_all <=VEGE;
            end if;
        when VEGE =>
            kov_all<=RDY;
            --Ri,Rk, barmilyen feluliras??
end

---Ri es Ri_next 32 bites
WITH akt_all SELECT 
    Ri_next <=  Ri  WHEN RDY,
                T1  WHEN INIT_A,
                Ri-1 WHEN Delay_1,
                Ri when Dek_1,
                T2 when INIT_B,
                Ri-'1' when DELAY_2,
                Rt when KONST,
                T3 when INIT_C,
                Ri-'1' when DELAY_3,
                Rt when INK,
                Ri when VEGE;--others kell ide meg
		
--WITH akt_all SELECT 
    Rk_next <=  Rk  WHEN RDY,
                N1  WHEN INIT_A,
                Rk WHEN Delay_1,
                Rk-'1' when Dek_1,
                N2 when INIT_B,
                Rk when DELAY_2,
                Rk-'1' when KONST,
                N3 when INIT_C,
                Rk when DELAY_3,
                Rk-'1' when INK,
                Ri when VEGE;
                
    Rt_next <=  Rt  WHEN RDY,
                T1  WHEN INIT_A,
                Rt WHEN Delay_1,
                Rt-d1 when Dek_1,
                T2 when INIT_B,
                Rt when DELAY_2,
                Rt-d1 when KONST,
                T3 when INIT_C,
                Rt when DELAY_3,
                Rt-d3 when INK,
                Rt when VEGE;

end Behavioral;
